using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPreviewData : MonoBehaviour
{
    [SerializeField] ItemManager.ItemId _ItemId;
    public ItemManager.ItemId ItemId
    {
        get { return _ItemId; }
    }

    [SerializeField] private Sprite _PreviewItemImage;
    public Sprite PreviewItemImage
    {
        get { return _PreviewItemImage; }
    }
    [SerializeField] private string _PreviewItemName;
    public string PreviewItemName
    {
        get { return _PreviewItemName; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
