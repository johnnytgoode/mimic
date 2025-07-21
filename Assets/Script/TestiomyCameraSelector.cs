using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static WitnessManager;

[Serializable]
public class TestiomyCameraSelector
{

    /// <summary>
    /// selector�̏��
    /// </summary>
    public enum TestimonySelectState
    {
        Idle,
        Activate,
        Select,
    }

    /// <summary>
    /// �@���݂�selector�̏��
    /// </summary>
    private TestimonySelectState _State = TestimonySelectState.Idle;

    /// <summary>
    /// ���ݑI�����Ă���،��i�ؐl�H�j
    /// </summary>
    private int _CurrentSelectTestimony = 0;

    /// <summary>
    /// �؂�ւ��J�������X�g�iInspector�ݒ�j
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
        foreach (GameObject camera in _SelectCameraList)
        {
            camera.SetActive(false);
        }
        activateSelectTestimonyCamera(0);
    }

    public void selectTestimony(int testimony)
    {

        if (testimony == _SelectCameraList.Count)
        {
            return;
        }
        else if (testimony < 0)
        {
            return;
        }

        activateSelectTestimonyCamera(testimony);
    }

    public void endSelectTestimony()
    {
        foreach (GameObject camera in _SelectCameraList)
        {
            camera.SetActive(false);
        }
    }

    private void activateSelectTestimonyCamera(int select)
    {
        foreach (GameObject camera in _SelectCameraList)
        {
            camera.SetActive(false);
        }
        _SelectCameraList[select].SetActive(true);
    }

}
