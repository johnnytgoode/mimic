using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem;

public class DialogueWindow : GUIBase
{

    public override GUIManager.GUIID GUIId
    {
        get
        {
            return GUIManager.GUIID.DialogueWindow;
        }
    }

    private enum State
    {
        Init,
        Type,
        InputWait,
        Finish,
    }

    /// <summary>
    /// èÛë‘
    /// </summary>
    private State _State;

    private TextMeshProUGUI _DialogueText = null;

    // Start is called before the first frame update
    void Start()
    {
        _DialogueText = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(_State)
        {
            case State.Init:
                {
                    _State = State.InputWait;
                    break;
                }
                case State.Type:
                {
                    _State = State.InputWait;
                    break;
                }
                case State.InputWait:
                {
                    if (Gamepad.current[GamepadButton.A].wasPressedThisFrame)
                    {
                        _State = State.Finish;
                    }
                    break;
                }
                case State.Finish:
                {
					close();
                    break;
                }
        }
    }

    public void setText(string text)
    {
        _DialogueText.text = text;
        _State = State.Type;
    }

    public bool isInputWait()
    {
        return _State == State.InputWait;
    }

	public void close()
	{

		GUIManager.Instance.closeGUI(GUIManager.GUIID.DialogueWindow);

		// âº
		_State = State.Init;
	}

}
