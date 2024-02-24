using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceManager : SingletonMonoBehaviour<EvidenceManager>
{
    public enum EvidenceId
    {
        None = 0,
        Trash,
        RoomNo,

        Num
    }

    [Serializable]
    public class EvidenceToFlag
    {
        public EvidenceId Id;
        public LoopManager.ActionFlag ActionFlag;
    }

    [SerializeField]public List<EvidenceToFlag> _EvidenceToFlags = new List<EvidenceToFlag>();

    /// <summary>
    /// 証拠のプレハブデータリスト
    /// </summary>
    [SerializeField]private List<GameObject> _EvidencePrefabList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 証拠品を使う
    /// </summary>
    /// <param name="id"></param>
    public void useEvidence(EvidenceId id)
    {
        var flag = evidenceIdToActionFlag(id);
        LoopManager.Instance.setActionFlag(((int)flag));
    }

    public LoopManager.ActionFlag evidenceIdToActionFlag(EvidenceId id)
    {
        foreach(var evidence in  _EvidenceToFlags)
        {
            if(evidence.Id == id)
            {
                return evidence.ActionFlag;
            }
        }
        return LoopManager.ActionFlag.C_Sabori;
        
    }

    /// <summary>
    /// 証拠データ取得
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Evidence getEvdenceData(EvidenceId id)
    {
        foreach(var evidence in _EvidencePrefabList)
        {
            var data = evidence.GetComponent<Evidence>();
            if(data != null)
            {
                if(data.Id == id)
                {
                    return data;
                }
            }
        }
        return null;
    }
}
