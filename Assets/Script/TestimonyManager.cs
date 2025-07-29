using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestimonyManager : SingletonMonoBehaviour<TestimonyManager>
{

	public enum TestimonyType
	{
		WitnessAction,
		Object
	}

	public enum TestimonyActorID
	{
		None,

		_A,
		_B,
		_C,
		_D
	}

	public enum TestimonyID
	{
		_000,
		_001,
		_002, 
		_003,
		_004,
		_005,
		_006,
		_007,
		_008,
		_009,

	}

	/// <summary>
	/// �،��f�[�^�����W
	/// </summary>
	private List<TestimonyData> _TestimonyDataList = new List<TestimonyData>();

	/// <summary>
	/// �A�N�^�[�Q�[���I�u�W�F�N�g
	/// </summary>
	[SerializeField]
	private List<GameObject> _TestimonyActorGameObjectList = new List<GameObject>();
	public List<GameObject> TestimonyActorGameObjectList => _TestimonyActorGameObjectList;

	private List<ITestimonyActor> _TestimonyActorList = new List<ITestimonyActor>();
	public List<ITestimonyActor> TestimonyActorList => _TestimonyActorList;

	// Start is called before the first frame update
	void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	//TODO *�f�[�^�̎��Ԃ�������Ɉڂ���������Ŋ�������悤�ɂȂ�\��
	public void setupTestimonyDataList()
	{
		_TestimonyDataList.Clear();
		// TODO:TestimonyManager���ŕێ��i���W�j����悤�ɏC��
		foreach (var gameObj in WitnessManager.Instance.WitnessActionDataObj)
		{
			var action = gameObj.GetComponent<WitnessPartActionData>();
			foreach (var actionData in action.WitnessActionList)
			{
				var data = actionData.Testimony;
				if(data != null)
				{
					// TODO:��ł����Ǝ蓮�Őݒ肷��
					data.PartNo = actionData.Part;
					_TestimonyDataList.Add(data);
				}
			}

		}
	}

	/// <summary>
	/// �w��̃p�[�g�ɑ�����،��f�[�^��Ԃ�
	/// </summary>
	/// <param name="part"></param>
	/// <returns></returns>
	public List<TestimonyData> getCurrentPartTestimonyDataList(int part)
	{
		List<TestimonyData> result = new List<TestimonyData>();
		
		foreach (var data in _TestimonyDataList)
		{
			if(data.PartNo == part)
			{
				result.Add(data);
			}
		}
		return result;

	}

	/// <summary>
	/// �،��̎��s�ҁi���j����Ԃ�
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public string getTestimonyAcorName(TestimonyID id)
	{
		var data = _TestimonyDataList.Find(x => x.TestimonyId == id);
		return data.ActorName;
	}

	/// <summary>
	/// �،��̓��e�e�L�X�g��Ԃ�
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public string getTestimonyText(TestimonyID id)
	{
		//TODO: �˂�������O��ŕԂ��e�L�X�g���A�锻������ށc�H

		var data = _TestimonyDataList.Find(x => x.TestimonyId == id);
		return data.BaseTestimony;
	}

	public TestimonyActorID getTestimonyActiorID(TestimonyID id)
	{
		var data = _TestimonyDataList.Find(x => x.TestimonyId == id);
		return data.TestimonyActorID;
	}
}
