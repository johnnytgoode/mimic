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
    /// パート開始位置にリセット
    /// </summary>
    public void resetPlayerPosition()
    {
        if( _Player != null ) 
        {
            _PLCtrl.resetPartTransform();        
        }
    }
}
