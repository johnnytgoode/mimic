using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        WitnessName.text = "変更成功";
        Testimony.text = "変更成功";
        EvidenceName.text = "変更成功";
        EvidenceDescription.text = "変更成功";

        // 選択可能なID初期化
        _WitnessIds.Add(WitnessManager.WitnessId.A);
        _WitnessIds.Add(WitnessManager.WitnessId.B);

        _EvidenceIds.Add(EvidenceManager.EvidenceId.Trash);
        _EvidenceIds.Add(EvidenceManager.EvidenceId.RoomNo);

    }

    // Update is called once per frame
    void Update()
    {
        switch(_State)
        {
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
        }
        
    }

    /// <summary>
    /// 証言選択
    /// </summary>
    private void testimonySelect()
    {
    }

    /// <summary>
    /// 証拠選択
    /// </summary>
    private void evidenceSelect()
    {

    }
}
