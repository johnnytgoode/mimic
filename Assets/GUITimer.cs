using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUITimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TimerGUIObj = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timer = LoopManager.Instance.LoopPartRestTime;
        _TimerGUIObj.text = timer.ToString("N2");
    }
}
