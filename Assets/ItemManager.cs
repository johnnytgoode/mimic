using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : SingletonMonoBehaviour<ItemManager>
{

    public enum ItemId
    {
        Key,        // ��

        Max,

    }

    /// <summary>
    /// �擾�A�C�e�����X�g
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
    /// �A�C�e���擾
    /// </summary>
    /// <param name="id"></param>
    public void addItem(ItemId id)
    {
        _Items.Add(id);
    }
}
