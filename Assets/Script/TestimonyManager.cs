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
	/// 証言データを収集
	/// </summary>
	private List<TestimonyData> _TestimonyDataList = new List<TestimonyData>();

	/// <summary>
	/// アクターゲームオブジェクト
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


	//TODO *データの実態をこちらに移したら内部で完結するようになる予定
	public void setupTestimonyDataList()
	{
		_TestimonyDataList.Clear();
		// TODO:TestimonyManager側で保持（収集）するように修正
		foreach (var gameObj in WitnessManager.Instance.WitnessActionDataObj)
		{
			var action = gameObj.GetComponent<WitnessPartActionData>();
			foreach (var actionData in action.WitnessActionList)
			{
				var data = actionData.Testimony;
				if(data != null)
				{
					// TODO:後でちゃんと手動で設定する
					data.PartNo = actionData.Part;
					_TestimonyDataList.Add(data);
				}
			}

		}
	}

	/// <summary>
	/// 指定のパートに属する証言データを返す
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
	/// 証言の実行者（物）名を返す
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public string getTestimonyAcorName(TestimonyID id)
	{
		var data = _TestimonyDataList.Find(x => x.TestimonyId == id);
		return data.ActorName;
	}

	/// <summary>
	/// 証言の内容テキストを返す
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public string getTestimonyText(TestimonyID id)
	{
		//TODO: 突きつけ正解前後で返すテキストを帰る判定を挟む…？

		var data = _TestimonyDataList.Find(x => x.TestimonyId == id);
		return data.BaseTestimony;
	}

	public TestimonyActorID getTestimonyActiorID(TestimonyID id)
	{
		var data = _TestimonyDataList.Find(x => x.TestimonyId == id);
		return data.TestimonyActorID;
	}
}
