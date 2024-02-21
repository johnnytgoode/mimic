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
    /// �T���l�C��
    /// </summary>
    [SerializeField] private Sprite _Tmb;

    /// <summary>
    /// ���O
    /// </summary>
    [SerializeField] private string _Name;

    /// <summary>
    /// ������
    /// </summary>
    [SerializeField] private string _Description;
}
