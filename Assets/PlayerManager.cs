using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{
    [SerializeField] private GameObject _Player = null;
    private Humanoid _PLCtrl = null;

    // Start is called before the first frame update
    void Start()
    {
        if(_Player != null)
        {
            _PLCtrl = _Player.GetComponent<ThirdPersonController>();
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �p�[�g�J�n�ʒu�Ƀ��Z�b�g
    /// </summary>
    public void resetPlayerPosition(int partNo)
    {
        if( _Player != null ) 
        {
            _PLCtrl.resetPartTransform(partNo);        
        }
    }

    /// <summary>
    /// �w��̃p�[�g�̊J�n�ʒu��ݒ�
    /// </summary>
    /// <param name="partNo"></param>
    /// <param name="pos"></param>
    public void setPlayerPartResetPos(int partNo)
    {
        if (_Player != null)
        {
            _PLCtrl.setPartStartPos(partNo);
        }
    }
}
