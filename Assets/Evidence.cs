using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    /// <summary>
    /// ID
    /// </summary>
    [SerializeField] private EvidenceManager.EvidenceId _Id;
    public EvidenceManager.EvidenceId Id { get { return _Id; } }

    /// <summary>
    /// サムネイル
    /// </summary>
    [SerializeField] private Sprite _Tmb;
    public Sprite Tmb { get { return _Tmb; } }

    /// <summary>
    /// 名前
    /// </summary>
    [SerializeField] private string _Name;
    public string Name { get { return _Name; } }

    /// <summary>
    /// 説明分
    /// </summary>
    [SerializeField] private string _Description;
    public string Description { get { return _Description; } }

}
