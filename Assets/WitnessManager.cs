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
        }
    }
}
