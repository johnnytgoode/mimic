using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    private bool _IsPause = false;

    public bool IsPause
    {
        get { return _IsPause;}
        set {
            if (_IsPause == value)
                return;
            _IsPause = value;
            Pause(_IsPause);
        }
    }

    [SerializeField] private GameObject _PauseGUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    private void Pause(bool pause)
    {
        if(pause)
        {
            Time.timeScale = 0;

            _PauseGUI.SetActive(true);
            GUIManager.Instance.openGUI(GUIManager.GUIID.ThrustMenu);
        }
        else
        {
            Time.timeScale = 1.0f;
            _PauseGUI.SetActive(false);
            GUIManager.Instance.closeGUI(GUIManager.GUIID.ThrustMenu);


        }
    }
}
