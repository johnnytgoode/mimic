using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : InteractObject
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

    /// <summary>
    /// �M�~�b�N�����s���邱�Ƃ��ł��邩
    /// </summary>
    /// <returns></returns>
    public bool canActivate()
    {
        // �A�C�e���w�肪�Ȃ��ꍇ��true
        if(_requestItemId == ItemManager.ItemId.None)
        {
            return true;
        }

        return ItemManager.Instance.hasItem(_requestItemId);
    }

    /// <summary>
    /// �M�~�b�N���N��
    /// </summary>
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

            if (_InteractGUI != null)
            {
                _InteractGUI.SetActive(false);
            }
            _IsInteracted = true;

        }

    }

    /// <summary>
    /// �g���K�R���W�����ɓ��������̏���
    /// </summary>
    /// <param name="collision"></param>

    public virtual void OnTriggerEnter(Collider other)
    {
        if (_IsInteracted)
        {
            return;
        }

        if(canActivate() == false)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            if(_InteractGUI != null)
            {
                _InteractGUI.SetActive(true);
            }
        }
    }

    /// <summary>
    ///�g���K�R���W�������甲�����Ƃ�
    /// </summary>
    /// <param name="other"></param>
    public virtual void OnTriggerExit(Collider other)
    {
        if (_IsInteracted)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            if (_InteractGUI != null)
            {
                _InteractGUI.SetActive(false);
            }
        }
    }
}
