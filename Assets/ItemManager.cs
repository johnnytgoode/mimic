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

        Key,        // ��
        Knife,      // �i�C�t
        DoorRose,    // ���[���}�[�N

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

    /// <summary>
    /// �؋��i���g��
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
