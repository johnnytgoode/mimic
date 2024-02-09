using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : SingletonMonoBehaviour<ItemManager>
{

    public enum ItemId
    {
        None,

        Key,        // ��
        Knife,      // �i�C�t

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
        Debug.Log("add item" + id.ToString());

        _Items.Add(id);
    }

    /// <summary>
    /// �A�C�e���̏��O
    /// </summary>
    /// <param name="id"></param>
    public  void removeItem(ItemId id) 
    {
        _Items.Remove(id);
    }

    /// <summary>
    /// �A�C�e���������Ă邩
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool hasItem(ItemId id)
    {
        return _Items.Contains(id);
    }
}
