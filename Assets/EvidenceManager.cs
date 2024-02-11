using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceManager : SingletonMonoBehaviour<EvidenceManager>
{
    public enum EvidenceId
    {
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// èÿãíïiÇégÇ§
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
}
