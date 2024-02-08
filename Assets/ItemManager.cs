using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : SingletonMonoBehaviour<ItemManager>
{

    public enum ItemId
    {
        Key,        // 鍵

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
        _Items.Add(id);
    }
}
