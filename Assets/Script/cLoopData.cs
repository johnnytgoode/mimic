using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cLoopData
{
    /// <summary>
    /// ステージのID（後で定義を切る）
    /// </summary>
    public int _LoopStateId = 0;

    // パートの最大数
    public int _LoopPartNumMax = 0;

    /// <summary>
    /// ループパートデータリスト
    /// </summary>
    public List<cLoopPartData> _LoopPartDataList = new List<cLoopPartData>();

    public int _CurrentLoopNo = 0;

    /// <summary>
    /// ループが終了したか
    /// </summary>
    public bool isLoopPartFinish()
    {
        if(_LoopPartDataList.Count > 0 && _CurrentLoopNo < _LoopPartDataList.Count)
        {
           return _LoopPartDataList[_CurrentLoopNo]._IsLoopPartFinish;
        }

        return false;
    }

    public float getLoopPartTime()
    {
        if (_LoopPartDataList.Count > 0 && _CurrentLoopNo < _LoopPartDataList.Count)
        {
            return _LoopPartDataList[_CurrentLoopNo]._LoopPartTime;
        }

        return 0.0f;
    }

    /// <summary>
    /// ループパートのデータ
    /// </summary>
    [System.Serializable]
    public class cLoopPartData
    {
        public float _LoopPartTime = 0.0f;

        public bool _IsLoopPartFinish = false;
    }
}
