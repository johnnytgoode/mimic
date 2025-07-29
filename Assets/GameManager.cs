using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    public enum GameState
    {
        Main,
        TestimonySelect,
        Scenario,
    }

    private GameState _State = GameState.Main;

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
        switch(_State)
        {
            case GameState.Main:
                {
                    main();
                    break;
                }
                case GameState.TestimonySelect:
                {
                    testimonySelect();
                    break;
                }
            case GameState.Scenario:
                {
					scenario();
                    break;
                }

        }



    }

    private void main()
    {
        LoopManager.Instance.updateLoop();

        if (Gamepad.current[GamepadButton.LeftShoulder].wasPressedThisFrame)
        {
            _State = GameState.TestimonySelect;

            GUIManager.Instance.openGUI(GUIManager.GUIID.ThrustMenu);
            //LoopManager.Instance.startTestimonySelect();
        }
    }

    private void testimonySelect()
    {
        if(GUIManager.Instance.isOpen(GUIManager.GUIID.ThrustMenu) == false)
        {
            var gui = GUIManager.Instance.getGUI(GUIManager.GUIID.ThrustMenu) as GUIThrustMenu;
            if (gui != null)
            {
                var finishType = gui.CurrentFinishType;
                switch(finishType)
                {
                    case GUIThrustMenu.FinishType.Cancel:
                        {
                            _State = GameState.Main;

                            break;
                        }
                        case GUIThrustMenu.FinishType.ThrustSuccess:
                        {
                            _State = GameState.Scenario;
                            GUIManager.Instance.openGUI(GUIManager.GUIID.DialogueWindow);
                            break;
                        }
                        case GUIThrustMenu.FinishType.ThrustFail:
                        {
                            break;
                        }
                }
            }
        }
    }

	private void scenario()
	{
		if(GUIManager.Instance.isOpen(GUIManager.GUIID.DialogueWindow) == false)
		{
			_State = GameState.Main;

			LoopManager.Instance.endTestimonySelect();
		}
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
