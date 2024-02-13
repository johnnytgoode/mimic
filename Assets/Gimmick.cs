using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] GimmickManager.GimmickId _GimmickId;
    public GimmickManager.GimmickId GimmickId { get { return _GimmickId; } }

    [SerializeField] ItemManager.ItemId _requestItemId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool canActivate()
    {
        // �A�C�e���w�肪�Ȃ��ꍇ��true
        if(_requestItemId == ItemManager.ItemId.None)
        {
            return true;
        }

        return ItemManager.Instance.hasItem(_requestItemId);
    }

    public void activateGimmick()
    {
        if(canActivate())
        {
            Debug.Log("activate Gimmick" + GimmickId.ToString());

            if(GimmickId == GimmickManager.GimmickId.LockedDoor) 
            {
                // ���Ńh�A�̓����莩�̂��̂��̂��Ȃ���
                gameObject.SetActive(false);
            }
            else if(GimmickId == GimmickManager.GimmickId.Kill)
            {
                // �i�s�t���O�𗧂Ă�
                LoopManager.Instance.setActionFlag(((int)LoopManager.ActionFlag.A_Kill));
            }
            else if (GimmickId == GimmickManager.GimmickId.RoomChange)
            {
                LoopManager.Instance.setActionFlag(((int)LoopManager.ActionFlag.D_RoomChange));
            }

        }

    }
}
