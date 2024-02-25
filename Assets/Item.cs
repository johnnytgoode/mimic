using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    /// <summary>
    /// �A�C�e��Id
    /// </summary>
    [SerializeField] ItemManager.ItemId _ItemId;
    public ItemManager.ItemId ItemId
    {
        get { return _ItemId; }
    }

    /// <summary>
    /// �C���^���N�g�pGUI
    /// </summary>
    [SerializeField] private GameObject _InteractGUI;

    /// <summary>
    /// ���ς݂��ǂ���
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
    /// �擾
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

        Debug.Log("�A�C�e���擾:" + ItemId);
    }

    /// <summary>
    /// �A�C�e���̖�����
    /// </summary>
    public void deactivateItem()
    {
        _InteractGUI.SetActive(false);

    }

    /// <summary>
    /// �g���K�R���W�����ɓ��������̏���
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
    ///�g���K�R���W�������甲�����Ƃ�
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
