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
    /// �ؐl�R���|�[�l���g���X�g
    /// </summary>
    private List<Witness> _WitnessList = new List<Witness>();

    public IReadOnlyList<Witness> WitnessList
    {
        get { return _WitnessList; }
    }

    /// <summary>
    /// �ؐl�v���n�u���X�g
    /// </summary>
    [SerializeField]private List<GameObject> _WitnessPrefabList = new List<GameObject>();

    /// <summary>
    /// �،��f�[�^���X�g
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
    /// �ؐl�̒ǉ�
    /// </summary>
    /// <param name="witness"></param>
    public void addWitness(Witness witness)
    {
        _WitnessList.Add(witness);
    }

    /// <summary>
    /// �ؐl���X�g�̃N���A
    /// </summary>
    public void clearWitness()
    {
        _WitnessList.Clear();
    }

    /// <summary>
    /// ���̃p�[�g�̃A�N�V���������ׂĊ������Ă邩
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
    /// �v�lFSM�̍ĊJ�i�p�[�g�̐i�s�A���Z�b�g���g�p�z��j
    /// </summary>
    public void retartThinkFSM()
    {
        foreach (var witness in _WitnessList)
        {
            witness.restartThinkFSM();
        }

    }

    /// <summary>
    /// �p�[�g���Ƃ̊J�n�ʒu�ɖ߂��i���[�v���Z�b�g�p�j
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
    /// �����o���̃e�L�X�g�Z�b�g
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
    /// �w�肵��ID�̏ؐl�f�[�^�擾
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
    /// �،��f�[�^�擾
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
    /// �،��擾
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
