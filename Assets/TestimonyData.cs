using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ØŒ¾ƒf[ƒ^")]
public class TestimonyData : ScriptableObject
{
    /// <summary>
    /// ”­Œ¾ÒID
    /// </summary>
    public WitnessManager.WitnessId WitnessId;

    public int Stage = -1;
    public int PartNo = -1;

    public string BaseTestimony;
    public LoopManager.ActionFlag ActionFlag;
    public string UpdateTestimony;
}
