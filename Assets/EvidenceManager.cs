using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceManager : SingletonMonoBehaviour<EvidenceManager>
{
    public enum EvidenceId
    {
        RoomNo,

        Num
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Ø‹’•i‚ğg‚¤
    /// </summary>
    /// <param name="id"></param>
    public void useEvidence(EvidenceId id)
    {
        LoopManager.Instance.setActionFlag(((int)id));
    }
}
