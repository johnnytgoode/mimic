using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIBase : MonoBehaviour
{
    // GUI���ʗpId�i�p����Ŏ�����ID��Ԃ��悤override�j
    public virtual GUIManager.GUIID GUIId
    {
        get
        {
            return GUIManager.GUIID.None;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
