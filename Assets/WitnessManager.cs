using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WitnessManager : SingletonMonoBehaviour<WitnessManager>
{
    public enum WitnessId
    {
        None,
        A,
        B,
        C,
        D,
        E,

        Num,
    }

    /// <summary>
    /// 証人コンポーネントリスト
    /// </summary>
    private List<Witness> _WitnessList = new List<Witness>();

    public IReadOnlyList<Witness> WitnessList
    {
        get { return _WitnessList; }
    }

    /// <summary>
    /// 証人プレハブリスト
    /// </summary>
    [SerializeField]private List<GameObject> _WitnessPrefabList = new List<GameObject>();

    /// <summary>
    /// 証言データリスト
    /// </summary>
    [SerializeField]private List<TestimonyData> _TestimonyDataList = new List<TestimonyData>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 証人の追加
    /// </summary>
    /// <param name="witness"></param>
    public void addWitness(Witness witness)
    {
        _WitnessList.Add(witness);
    }

    /// <summary>
    /// 証人リストのクリア
    /// </summary>
    public void clearWitness()
    {
        _WitnessList.Clear();
    }

    /// <summary>
    /// そのパートのアクションがすべて完了してるか
    /// </summary>
    /// <returns></returns>
    public bool isAllWitnessPartActionSuccess()
    {
        foreach (var witness in _WitnessList)
        {
            if(witness.isPartActionSuccess() ==false)
            {
                Debug.Log(witness.gameObject.name + "is not actionSuccess");
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 思考FSMの再開（パートの進行、リセット時使用想定）
    /// </summary>
    public void retartThinkFSM()
    {
        foreach (var witness in _WitnessList)
        {
            witness.restartThinkFSM();
        }

    }

    /// <summary>
    /// パートごとの開始位置に戻す（ループリセット用）
    /// </summary>
    /// <param name="part"></param>
    public void resetPartStartTransform(int part)
    {
        foreach (var witness in _WitnessList)
        {
            witness.resetPartTransform(part);
            witness.setPartActionSuccess(false);
        }
    }

    public void setPartResetPos(int part)
    {
        foreach (var witness in _WitnessList)
        {
            witness.setPartStartPos(part);
        }

    }

    /// <summary>
    /// 吹き出しのテキストセット
    /// </summary>
    /// <param name="partNo"></param>
    public void setBaroonText(int partNo)
    {
        foreach (var witness in _WitnessList)
        {
            witness.setPartBaroonText(partNo);
        }

    }

    /// <summary>
    /// 指定したIDの証人データ取得
    /// </summary>
    /// <param name="witnessId"></param>
    /// <returns></returns>
    public WitnessData getWitnessData(WitnessManager.WitnessId witnessId)
    {
        foreach(var witness in _WitnessPrefabList)
        {
            var data = witness.GetComponent<WitnessData>();
            if(data == null)
            {
                continue;
            }
            if(data.Id == witnessId)
            {
                return data;
            }
        }

        return null;
    }

    /// <summary>
    /// 証言データ取得
    /// </summary>
    /// <param name="partNo"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public TestimonyData getTestimonyData(int partNo, WitnessManager.WitnessId id)
    {
        foreach (var testimony in _TestimonyDataList)
        {
            if (testimony.WitnessId != id)
            {
                continue;
            }
            if (testimony.PartNo == partNo)
            {
                continue;
            }

            return testimony;
        }

        return null;

    }

    /// <summary>
    /// 証言取得
    /// </summary>
    /// <param name="partNo"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public string getTestimony(int partNo,WitnessManager.WitnessId id)
    {
        foreach(var testimony in _TestimonyDataList)
        {
            if(testimony.WitnessId != id)
            {
                continue;
            }
            if(testimony.PartNo == partNo)
            {
                continue;
            }

            return testimony.getTextimony();
        }

        return "";
    }
}
