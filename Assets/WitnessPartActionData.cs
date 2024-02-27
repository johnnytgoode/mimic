using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitnessPartActionData : MonoBehaviour
{
    /// <summary>
    /// 証人ID
    /// </summary>
    [SerializeField] private WitnessManager.WitnessId _WitnessId;
    public WitnessManager.WitnessId WitnessId { get { return _WitnessId; } }

    /// <summary>
    /// 一パートあたりのデータ
    /// </summary>
    [Serializable]
    public class WitnessActionData
    {
        /// <summary>
        /// パート番号
        /// </summary>
        [SerializeField] private int _Part;
        public int Part { get { return _Part; } }
        /// <summary>
        /// BehaiviorTree
        /// </summary>
        [SerializeField] private GameObject _BTObject;
        public GameObject BTObject { get { return _BTObject; } }
        /// <summary>
        /// 証言データ
        /// </summary>
        [SerializeField] private TestimonyData _Testimony;
        public TestimonyData Testimony { get {  return _Testimony; } }
    }

    /// <summary>
    /// パートごとの
    /// </summary>
    [SerializeField] private List<WitnessActionData> _WitnessActionList = new List<WitnessActionData>();
    public List<WitnessActionData> WitnessActionList => _WitnessActionList;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
