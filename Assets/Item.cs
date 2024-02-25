using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    /// <summary>
    /// アイテムId
    /// </summary>
    [SerializeField] ItemManager.ItemId _ItemId;
    public ItemManager.ItemId ItemId
    {
        get { return _ItemId; }
    }

    /// <summary>
    /// インタラクト用GUI
    /// </summary>
    [SerializeField] private GameObject _InteractGUI;

    /// <summary>
    /// 干渉済みかどうか
    /// </summary>
    private bool _IsInteracted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 取得
    /// </summary>
    public void acquisition()
    {
        if(_IsInteracted)
        {
            return;
        }

        _IsInteracted = true;
        ItemManager.Instance.addItem(ItemId);

        deactivateItem();

        Debug.Log("アイテム取得:" + ItemId);
    }

    /// <summary>
    /// アイテムの無効化
    /// </summary>
    public void deactivateItem()
    {
        _InteractGUI.SetActive(false);

    }

    /// <summary>
    /// トリガコリジョンに入った時の処理
    /// </summary>
    /// <param name="collision"></param>

    public virtual void OnTriggerEnter(Collider other)
    {
        if(_IsInteracted)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            _InteractGUI.SetActive(true);
        }
    }

    /// <summary>
    ///トリガコリジョンから抜けたとき
    /// </summary>
    /// <param name="other"></param>
    public virtual void OnTriggerExit(Collider other)
    {
        if (_IsInteracted)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            _InteractGUI.SetActive(false);
        }
    }

}
