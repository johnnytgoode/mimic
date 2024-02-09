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
        // アイテム指定がない場合はtrue
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

            // 仮でドアの当たり自体そのものをなくす
            gameObject.SetActive(false);
        }

    }
}
