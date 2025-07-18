using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static WitnessManager;

[Serializable]
public class TestiomySelector
{

    /// <summary>
    /// selectorの状態
    /// </summary>
    public enum TestimonySelectState
    {
        Idle,
        Activate,
        Select,
    }

    /// <summary>
    /// 　現在のselectorの状態
    /// </summary>
    private TestimonySelectState _State = TestimonySelectState.Idle;

    /// <summary>
    /// 現在選択している証言（証人？）
    /// </summary>
    private int _CurrentSelectTestimony = 0;

    /// <summary>
    /// 切り替えカメラリスト（Inspector設定）
    /// </summary>
    [SerializeField] public List<GameObject> _SelectCameraList = new List<GameObject>();


    // Update is called once per frame
    void update()
    {

        switch(_State)
        {
            case TestimonySelectState.Idle:
                {

                    break;
                }
            case TestimonySelectState.Activate:
                {

                    _State = TestimonySelectState.Select;
                    break;
                }
                case TestimonySelectState.Select:
                {


                    break;
                }
        }

        //int partNo = LoopManager.Instance.getCurrentLoopPartNo();
        //var testimonyData = WitnessManager.Instance.getTestimonyData(partNo, (WitnessManager.WitnessId)_CurrentSelectTestimony);



    }

    public void startSelectTestimony()
    {
        _CurrentSelectTestimony = 0;
        foreach (GameObject camera in _SelectCameraList)
        {
            camera.SetActive(false);
        }
        _SelectCameraList[_CurrentSelectTestimony].SetActive(true);
    }

    public void addSelectTestimony()
    {
        _CurrentSelectTestimony++;
        if (_CurrentSelectTestimony == _SelectCameraList.Count)
        {
            _CurrentSelectTestimony = 0;
        }

        activateSelectTestimonyCamera();
    }

    public void subSelectTestimony()
    {
        _CurrentSelectTestimony--;
        if(_CurrentSelectTestimony < 0)
        {
            _CurrentSelectTestimony = _SelectCameraList.Count - 1;
        }
        activateSelectTestimonyCamera();
    }

    public void endSelectTestimony()
    {
        foreach (GameObject camera in _SelectCameraList)
        {
            camera.SetActive(false);
        }
    }

    private void activateSelectTestimonyCamera()
    {
        foreach (GameObject camera in _SelectCameraList)
        {
            camera.SetActive(false);
        }
        _SelectCameraList[_CurrentSelectTestimony].SetActive(true);
    }

}
