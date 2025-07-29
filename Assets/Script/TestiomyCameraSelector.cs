using Cinemachine;
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


	private class ActorCameraInfo
	{
		/// <summary>
		/// �J����
		/// </summary>
		private GameObject _Camera;

		/// <summary>
		/// �،�ID
		/// </summary>
		private TestimonyManager.TestimonyActorID _ActorId;

		public TestimonyManager.TestimonyActorID ActorId => _ActorId;

		/// <summary>
		/// �،�ID�Ǘ��p�N���X
		/// </summary>
		/// <param name="camera"></param>
		/// <param name="testimonyId"></param>
		public ActorCameraInfo(GameObject camera, TestimonyManager.TestimonyActorID actorId)
		{
			_Camera = camera;
			_ActorId = actorId;
		}

		public void setActive(bool v)
		{
			_Camera.SetActive(v);
		}
	}

	/// <summary>
	/// �A�N�^�[�̃J�������X�g
	/// </summary>
	private List<ActorCameraInfo> _ActorCameraList = new List<ActorCameraInfo>();

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

	public void setupActorCameraList()
	{
		foreach(var gameObj in TestimonyManager.Instance.TestimonyActorGameObjectList)
		{
			var cameraObj = gameObj.transform.Find("Virtual Camera").gameObject;

			var actorCmp = gameObj.GetComponent<ITestimonyActor>();

			_ActorCameraList.Add(new ActorCameraInfo( cameraObj,actorCmp.ActorId));
		}
	}

	public void selectTestimony(TestimonyManager.TestimonyID testimonyId)
	{
		//�،�ID���A�N�^�[ID�Ɋ��Z
		var actorID = TestimonyManager.Instance.getTestimonyActiorID(testimonyId);

		var camera = _ActorCameraList.Find(x=>x.ActorId == actorID);

		if (camera == null)
		{
			return;
		}
		foreach (var c in _ActorCameraList)
		{
			c.setActive(false);
		}
		camera.setActive(true);

	}

	public void endSelectTestimony()
	{
		foreach (var camera in _ActorCameraList)
		{
			camera.setActive(false);
		}
	}


}
