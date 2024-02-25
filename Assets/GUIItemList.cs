using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIItemList : MonoBehaviour
{

    [SerializeField] private List<GameObject> _ItemImageObjList = new List<GameObject>();
    private List<Image> _ItemImageList = new List<Image>();

    /// <summary>
    /// �������Ă�A�C�e�����X�g
    /// </summary>
    private List<ItemManager.ItemId> _Inventory = new List<ItemManager.ItemId>();

    // Start is called before the first frame update
    void Start()
    {
        // �����A�C�e�����X�g�摜�擾
        foreach(var obj in _ItemImageObjList)
        {
            var image = obj.GetComponent<Image>();
            _ItemImageList.Add(image);
        }

        foreach (var itemImage in _ItemImageList)
        {
            itemImage.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �������Ă�A�C�e����ǉ�
    /// </summary>
    /// <param name="itemId"></param>
    public void addInventory(ItemManager.ItemId itemId)
    {
        if (_Inventory.Contains(itemId) == false)
        {
            _Inventory.Add(itemId);
        }
        updateInventoryDisp();
    }

    /// <summary>
    /// �������Ă�A�C�e�����珜�O
    /// </summary>
    /// <param name="itemId"></param>
    public void removeInventory(ItemManager.ItemId itemId)
    {
        if (_Inventory.Contains(itemId) == true)
        {
            _Inventory.Remove(itemId);
        }
        updateInventoryDisp();
    }

    /// <summary>
    /// �����A�C�e�����X�g�\���X�V
    /// </summary>
    private void updateInventoryDisp()
    {
        foreach(var itemImage in _ItemImageList)
        {
            itemImage.enabled = false;
        }

        int itemIdx = 0;
        for(int i = _Inventory.Count - 1; i >= 0 ; i --)
        {
            // image�̎擾
            var previewData = ItemManager.Instance.getItemPreviewData(_Inventory[i]);
            if (previewData != null)
            {
                _ItemImageList[itemIdx].sprite = previewData.PreviewItemImage;
            }
            _ItemImageList[itemIdx].enabled = true;
            itemIdx++;
        }

    }

}
