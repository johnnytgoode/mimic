using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static cLoopData;

[System.Serializable]
public class cLoopData
{
    /// <summary>
    /// �X�e�[�W��ID�i��Œ�`��؂�j
    /// </summary>
    public int _LoopStateId = 0;

    // �p�[�g�̍ő吔
    public int _LoopPartNumMax = 0;

    /// <summary>
    /// ���[�v�p�[�g�f�[�^���X�g
    /// </summary>
    public List<cLoopPartData> _LoopPartDataList = new List<cLoopPartData>();

    public int _CurrentLoopNo = 0;


    public float getLoopPartTime(int partNo)
    {
        if (_LoopPartDataList.Count > 0 && _CurrentLoopNo < _LoopPartDataList.Count)
        {
            return _LoopPartDataList[partNo]._LoopPartTime;
        }

        return 0.0f;
    }

    /// <summary>
    /// ���[�v�p�[�g�̃f�[�^
    /// </summary>
    [System.Serializable]
    public class cLoopPartData
    {
        public float _LoopPartTime = 0.0f;

        public string Description;

    }
}

