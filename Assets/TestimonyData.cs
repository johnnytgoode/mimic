using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "�،��f�[�^")]
public class TestimonyData : ScriptableObject
{
    /// <summary>
    /// ������ID
    /// </summary>
    public WitnessManager.WitnessId WitnessId;

    public int Stage = -1;
    public int PartNo = -1;

    public string BaseTestimony;
    public EvidenceManager.EvidenceId EvidenceId;
    public string UpdateTestimony;

    public string getTextimony()
    {
        // �����B�����Ă���X�V��̏،���Ԃ�����

        return BaseTestimony;
    }
}
