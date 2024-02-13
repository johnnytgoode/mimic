using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EvidenceManager;

public class ItemManager : SingletonMonoBehaviour<ItemManager>
{

    public enum ItemId
    {
        None,

        Key,        // 鍵
        Knife,      // ナイフ
        DoorRose,    // ルームマーク

        Max,

    }

    [Serializable]
    public class ItemToFlag
    {
        public ItemId Id;
        public LoopManager.ActionFlag ActionFlag;
    }

    [SerializeField] public List<ItemToFlag> _ItemToFlags = new List<ItemToFlag>();

    /// <summary>
    /// 取得アイテムリスト
    /// </summary>
    private List<ItemId> _Items = new List<ItemId>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// アイテム取得
    /// </summary>
    /// <param name="id"></param>
    public void addItem(ItemId id)
    {
        Debug.Log("add item" + id.ToString());

        _Items.Add(id);
    }

    /// <summary>
    /// アイテムの除外
    /// </summary>
    /// <param name="id"></param>
    public  void removeItem(ItemId id) 
    {
        _Items.Remove(id);
    }

    /// <summary>
    /// アイテムを持ってるか
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool hasItem(ItemId id)
    {
        return _Items.Contains(id);
    }

    /// <summary>
    /// 証拠品を使う
    /// </summary>
    /// <param name="id"></param>
    public void useItem(ItemId id)
    {
        var flag = ItemToActionFlag(id);
        LoopManager.Instance.setActionFlag(((int)flag));
    }

    public LoopManager.ActionFlag ItemToActionFlag(ItemId id)
    {
        foreach (var item in _ItemToFlags)
        {
            if (item.Id == id)
            {
                return item.ActionFlag;
            }
        }
        return LoopManager.ActionFlag.C_Sabori;

    }
}
