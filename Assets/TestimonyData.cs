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
    public LoopManager.ActionFlag ActionFlag;
    public string UpdateTestimony;
}
