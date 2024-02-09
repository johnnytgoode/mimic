using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : SingletonMonoBehaviour<ItemManager>
{

    public enum ItemId
    {
        None,

        Key,        // 鍵
        Knife,      // ナイフ

        Max,

    }

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
}
