using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitnessManager : SingletonMonoBehaviour<WitnessManager>
{
    private List<Witness> _WitnessList = new List<Witness>();


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
        }
    }
}
