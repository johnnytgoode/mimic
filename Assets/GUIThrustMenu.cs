using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class GUIThrustMenu : MonoBehaviour
{
    private TextMeshProUGUI WitnessName;
    private TextMeshProUGUI Testimony;
    private Image Witness01Tmb;
    private Image Witness02Tmb;
    private Image Witness03Tmb;

    private TextMeshProUGUI EvidenceName;
    private TextMeshProUGUI EvidenceDescription;
    private Image Evidence01Tmb;
    private Image Evidence02Tmb;
    private Image Evidence03Tmb;

    private enum State
    {
        Init,
        TestimonySelect,
        EvidenceSelect,
        ThrustCheck,
        Finish,
    }

    /// <summary>
    /// 状態
    /// </summary>
    private State _State;

    /// <summary>
    /// 選択候補証人リスト
    /// </summary>
    private List<WitnessManager.WitnessId> _WitnessIds = new List<WitnessManager.WitnessId>();
    private int _CurrentSelectWitness = 0;

    /// <summary>
    /// 選択候補証拠品リスト
    /// </summary>
    private List<EvidenceManager.EvidenceId> _EvidenceIds = new List<EvidenceManager.EvidenceId>();
    private int _CurrentSelectEvidence = 0;

    // Start is called before the first frame update
    void Start()
    {
        WitnessName = GameObject.Find("witness01_Name").GetComponent<TextMeshProUGUI>();
        Testimony = GameObject.Find("TestimonyText").GetComponent<TextMeshProUGUI>();

        Witness01Tmb = GameObject.Find("witness01_tmb").GetComponent<Image>();
        Witness02Tmb = GameObject.Find("witness02_tmb").GetComponent<Image>();
        Witness03Tmb = GameObject.Find("witness03_tmb").GetComponent<Image>();

        EvidenceName = GameObject.Find("EvidenceName").GetComponent<TextMeshProUGUI>();
        EvidenceDescription = GameObject.Find("EvidenceDescriptionText").GetComponent<TextMeshProUGUI>();

        Evidence01Tmb = GameObject.Find("Evidence01").GetComponent<Image>();
        Evidence02Tmb = GameObject.Find("Evidence02").GetComponent<Image>();
        Evidence03Tmb = GameObject.Find("Evidence03").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

        switch(_State)
        {
            case State.Init:
                {
                    _CurrentSelectEvidence = 0;
                    _CurrentSelectWitness = 0;

                    setupWitnessIdList();
                    setupEvidenceIdList();

                    updateTestimonyDisp();
                    updateEvidenceDisp();

                    _State = State.TestimonySelect;

                    break;
                }

            case State.TestimonySelect:
                {
                    testimonySelect();
                    break;
                }
            case State.EvidenceSelect:
                {
                    evidenceSelect();
                    break;
                }
            case State.ThrustCheck:
                {
                    if(thrustCheck())
                    {
                        setThrustFlg();
                        Debug.Log("突きつけ成功！");
                        _State = State.Finish;
                    }
                    else
                    {
                        Debug.Log("突きつけ失敗…");
                    }

                    break;
                }
            case State.Finish:
                {
                    close();

                    break;
                }
        }
        
    }

    /// <summary>
    /// 突きつけメニューのオープン
    /// </summary>
    public void open()
    {
        _State = State.Init;
    }

    /// <summary>
    /// 突き詰めメニューのクローズ
    /// </summary>
    public void close()
    {
        // 仮
        _State = State.Init;
        GameManager.Instance.IsPause = false;
    }

    private void setupWitnessIdList()
    {
        var witnesses = WitnessManager.Instance.WitnessList;
        foreach(var witness in witnesses)
        {
            _WitnessIds.Add(witness.WitnessId);
        }

        _WitnessIds.Sort();
    }

    /// <summary>
    /// 証言選択
    /// </summary>
    private void testimonySelect()
    {
        if(Gamepad.current[GamepadButton.DpadRight].wasPressedThisFrame)
        {
            _CurrentSelectWitness++;
            Debug.Log("CurrentSelectWitness:" + _CurrentSelectWitness);

            if(_CurrentSelectWitness >= _WitnessIds.Count)
            {
                _CurrentSelectWitness = 0;
            }
            updateTestimonyDisp();
        }
        if (Gamepad.current[GamepadButton.DpadLeft].wasPressedThisFrame)
        {
            _CurrentSelectWitness--;
            Debug.Log("CurrentSelectWitness:" + _CurrentSelectWitness);

            if (_CurrentSelectWitness < 0)
            {
                _CurrentSelectWitness = _WitnessIds.Count - 1;
            }
            updateTestimonyDisp();
        }

        // 証言確定
        if (Gamepad.current[GamepadButton.A].wasPressedThisFrame)
        {
            _State = State.EvidenceSelect;
            Debug.Log("State ->" + _State);
        }
    }


    private void setupEvidenceIdList()
    {
        // 選択可能なID初期化
        _EvidenceIds.Add(EvidenceManager.EvidenceId.Trash);
        _EvidenceIds.Add(EvidenceManager.EvidenceId.RoomNo);

    }

    /// <summary>
    /// 証言データの表示更新
    /// </summary>
    private void updateTestimonyDisp()
    {
        int part = LoopManager.Instance._CurrentPart;

        var witnessId = _WitnessIds[_CurrentSelectWitness];

        var witnessData = WitnessManager.Instance.getWitnessData(witnessId);
        string witnessNameText = witnessData.Name;
        string testimonyText = WitnessManager.Instance.getTestimony(part, witnessId);

        WitnessName.text = witnessNameText;
        Testimony.text = testimonyText;

        var witnessTmb = witnessData.Tmb;
        Witness01Tmb.sprite = witnessTmb;
    }


    /// <summary>
    /// 証拠選択
    /// </summary>
    private void evidenceSelect()
    {
        if (Gamepad.current[GamepadButton.DpadRight].wasPressedThisFrame)
        {
            _CurrentSelectEvidence++;
            Debug.Log("CurrentSelectEvidence:" + _CurrentSelectEvidence);

            if (_CurrentSelectEvidence >= _EvidenceIds.Count)
            {
                _CurrentSelectEvidence = 0;
            }
            updateEvidenceDisp();
        }
        if (Gamepad.current[GamepadButton.DpadLeft].wasPressedThisFrame)
        {
            _CurrentSelectEvidence--;
            Debug.Log("CurrentSelectEvidence:" + _CurrentSelectEvidence);

            if (_CurrentSelectEvidence < 0)
            {
                _CurrentSelectEvidence = _EvidenceIds.Count - 1;
            }
            updateEvidenceDisp();
        }

        // 証言確定
        if (Gamepad.current[GamepadButton.A].wasPressedThisFrame)
        {
            _State = State.ThrustCheck;
            Debug.Log("State ->" + _State);

        }
    }

    /// <summary>
    /// 証拠表示更新
    /// </summary>
    private void updateEvidenceDisp()
    {
        int part = LoopManager.Instance._CurrentPart;
        var evidenceId = _EvidenceIds[_CurrentSelectEvidence];

        var evidenceData = EvidenceManager.Instance.getEvdenceData(evidenceId);
        if (evidenceData != null)
        {
            Evidence01Tmb.sprite = evidenceData.Tmb;

            EvidenceName.text = evidenceData.Name;
            EvidenceDescription.text = evidenceData.Description;
        }
    }

    /// <summary>
    /// 突きつけが成功？
    /// </summary>
    /// <returns></returns>
    private bool thrustCheck()
    {
        int part = LoopManager.Instance._CurrentPart;

        var witnessId = _WitnessIds[_CurrentSelectWitness];
        var testimonyData = WitnessManager.Instance.getTestimonyData(part, witnessId);
        if(testimonyData != null)
        {
            var evidenceId = _EvidenceIds[_CurrentSelectEvidence];
            if(testimonyData.EvidenceId == evidenceId)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 突きつけ成功した時の処理（フラグを立ててシナリオを呼び出す）
    /// </summary>
    private void setThrustFlg()
    {
        var evidenceId = _EvidenceIds[_CurrentSelectEvidence];
        var actionFlg = EvidenceManager.Instance.evidenceIdToActionFlag(evidenceId);

        LoopManager.Instance.setActionFlag(((int)actionFlg));
    }
}
