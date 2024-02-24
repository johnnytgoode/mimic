using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "証言データ")]
public class TestimonyData : ScriptableObject
{
    /// <summary>
    /// 発言者ID
    /// </summary>
    public WitnessManager.WitnessId WitnessId;

    public int Stage = -1;
    public int PartNo = -1;

    public string BaseTestimony;
    public EvidenceManager.EvidenceId EvidenceId;
    public string UpdateTestimony;

    public string getTextimony()
    {
        // 条件達成してたら更新後の証言を返す判定

        return BaseTestimony;
    }
}
