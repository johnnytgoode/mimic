using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIItemList : MonoBehaviour
{

    [SerializeField] private List<GameObject> _ItemImageObjList = new List<GameObject>();
    private List<Image> _ItemImageList = new List<Image>();

    /// <summary>
    /// 所持してるアイテムリスト
    /// </summary>
    private List<ItemManager.ItemId> _Inventory = new List<ItemManager.ItemId>();

    // Start is called before the first frame update
    void Start()
    {
        // 所持アイテムリスト画像取得
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
    /// 所持してるアイテムを追加
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
    /// 所持してるアイテムから除外
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
    /// 所持アイテムリスト表示更新
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
            // imageの取得
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
