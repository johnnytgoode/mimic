using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static WitnessManager;
using static GameManager;

public class GUIThrustMenu : GUIBase
{
    public override GUIManager.GUIID GUIId
    {
        get
        {
            return GUIManager.GUIID.ThrustMenu;
        }
    }

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
    /// �N���[�Y���̏�Ԓʒm
    /// </summary>
    public enum FinishType
    {
        None,
        Cancel,
        ThrustSuccess,
        ThrustFail,
    }

    private FinishType _CurrentFinishType = FinishType.None;
    public FinishType CurrentFinishType { get { return _CurrentFinishType; } }

    /// <summary>
    /// ���
    /// </summary>
    private State _State;

    /// <summary>
    /// �I�����ؐl���X�g
    /// </summary>
    private List<WitnessManager.WitnessId> _WitnessIds = new List<WitnessManager.WitnessId>();
    private int _CurrentSelectWitness = 0;

    /// <summary>
    /// �I�����؋��i���X�g
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

        if (Gamepad.current[GamepadButton.LeftShoulder].wasPressedThisFrame)
        {
            _State = State.TestimonySelect;
            _CurrentFinishType = FinishType.Cancel;


            LoopManager.Instance.endTestimonySelect();
        }

        switch (_State)
        {
            case State.Init:
                {
                    _CurrentSelectEvidence = 0;
                    _CurrentSelectWitness = 0;

                    setupWitnessIdList();
                    setupEvidenceIdList();

                    updateTestimonyDisp();
                    updateEvidenceDisp();

                    _CurrentFinishType = FinishType.None;

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
                        Debug.Log("�˂��������I");
                        _CurrentFinishType = FinishType.ThrustSuccess;
                    }
                    else
                    {
                        Debug.Log("�˂������s�c");
                        _CurrentFinishType = FinishType.ThrustFail;
                    }
                    _State = State.Finish;

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
    /// �˂������j���[�̃I�[�v��
    /// </summary>
    public void open()
    {
        _State = State.Init;
    }

    /// <summary>
    /// �˂��l�߃��j���[�̃N���[�Y
    /// </summary>
    public void close()
    {

        GUIManager.Instance.closeGUI(GUIManager.GUIID.ThrustMenu);

        // ��
        _State = State.Init;
        GameManager.Instance.IsPause = false;
    }

    private void setupWitnessIdList()
    {
        int part = LoopManager.Instance._CurrentPart;

        _WitnessIds = WitnessManager.Instance.getPartActiveWitnessId(part);

        _WitnessIds.Sort();
    }

    /// <summary>
    /// �،��I��
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
            // �J����
            LoopManager.Instance.selectTestimony(_CurrentSelectWitness);
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
            // �J����
            LoopManager.Instance.selectTestimony(_CurrentSelectWitness);
        }

        // �،��m��
        if (Gamepad.current[GamepadButton.A].wasPressedThisFrame)
        {
            _State = State.EvidenceSelect;
            Debug.Log("State ->" + _State);
        }
    }


    private void setupEvidenceIdList()
    {
        // �I���\��ID������
        _EvidenceIds.Add(EvidenceManager.EvidenceId.Trash);
        _EvidenceIds.Add(EvidenceManager.EvidenceId.RoomNo);

    }

    /// <summary>
    /// �،��f�[�^�̕\���X�V
    /// </summary>
    private void updateTestimonyDisp()
    {
        int part = LoopManager.Instance._CurrentPart;

        var witnessId = _WitnessIds[_CurrentSelectWitness];

        var witnessData = WitnessManager.Instance.getWitnessData(witnessId);
        string witnessNameText = witnessData.Name;
        var testimonyData = WitnessManager.Instance.getTestimonyData(part, witnessId);
        string testimonyText = "";
        if(testimonyData != null)
        {
            testimonyText = testimonyData.getTextimony();
        }

        WitnessName.text = witnessNameText;
        Testimony.text = testimonyText;

        var witnessTmb = witnessData.Tmb;
        Witness01Tmb.sprite = witnessTmb;
    }


    /// <summary>
    /// �؋��I��
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

        // �،��m��
        if (Gamepad.current[GamepadButton.A].wasPressedThisFrame)
        {
            _State = State.ThrustCheck;
            Debug.Log("State ->" + _State);

        }
    }

    /// <summary>
    /// �؋��\���X�V
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
    /// �˂����������H
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
    /// �˂��������������̏����i�t���O�𗧂ĂăV�i���I���Ăяo���j
    /// </summary>
    private void setThrustFlg()
    {
        var evidenceId = _EvidenceIds[_CurrentSelectEvidence];
        var actionFlg = EvidenceManager.Instance.evidenceIdToActionFlag(evidenceId);

        LoopManager.Instance.setActionFlag(((int)actionFlg));
    }
}
