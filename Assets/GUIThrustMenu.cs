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
    /// óÔ
    /// </summary>
    private State _State;

    /// <summary>
    /// IðóâØlXg
    /// </summary>
    private List<WitnessManager.WitnessId> _WitnessIds = new List<WitnessManager.WitnessId>();
    private int _CurrentSelectWitness = 0;

    /// <summary>
    /// IðóâØiXg
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

        WitnessName.text = "ÏX¬÷";
        Testimony.text = "ÏX¬÷";
        EvidenceName.text = "ÏX¬÷";
        EvidenceDescription.text = "ÏX¬÷";

        // IðÂ\ÈIDú»
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
    /// Ø¾Ið
    /// </summary>
    private void testimonySelect()
    {
    }

    /// <summary>
    /// ØIð
    /// </summary>
    private void evidenceSelect()
    {

    }
}
