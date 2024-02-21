using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitnessData : MonoBehaviour
{
    /// <summary>
    /// ID
    /// </summary>
    [SerializeField] private WitnessManager.WitnessId _Id;

    /// <summary>
    /// サムネイル
    /// </summary>
    [SerializeField] private Sprite _Tmb;

    /// <summary>
    /// 名前
    /// </summary>
    [SerializeField] private string _Name;

    /// <summary>
    /// 説明分
    /// </summary>
    [SerializeField] private string _Description;
}
