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
    /// ギミックを実行することができるか
    /// </summary>
    /// <returns></returns>
    public bool canActivate()
    {
        // アイテム指定がない場合はtrue
        if(_requestItemId == ItemManager.ItemId.None)
        {
            return true;
        }

        return ItemManager.Instance.hasItem(_requestItemId);
    }

    /// <summary>
    /// ギミックを起動
    /// </summary>
    public void activateGimmick()
    {
        if(canActivate())
        {
            Debug.Log("activate Gimmick" + GimmickId.ToString());

            if(GimmickId == GimmickManager.GimmickId.LockedDoor) 
            {
                // 仮でドアの当たり自体そのものをなくす
                gameObject.SetActive(false);
            }
            else if(GimmickId == GimmickManager.GimmickId.Kill)
            {
                // 進行フラグを立てる
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
    /// トリガコリジョンに入った時の処理
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
    ///トリガコリジョンから抜けたとき
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
