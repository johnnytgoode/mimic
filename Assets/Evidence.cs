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
    /// �T���l�C��
    /// </summary>
    [SerializeField] private Sprite _Tmb;
    public Sprite Tmb { get { return _Tmb; } }

    /// <summary>
    /// ���O
    /// </summary>
    [SerializeField] private string _Name;
    public string Name { get { return _Name; } }

    /// <summary>
    /// ������
    /// </summary>
    [SerializeField] private string _Description;
    public string Description { get { return _Description; } }

}
