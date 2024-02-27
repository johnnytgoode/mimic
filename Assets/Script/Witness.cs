using Arbor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Witness : Humanoid
{
    [SerializeField] private WitnessManager.WitnessId _WitnessId;
    public WitnessManager.WitnessId WitnessId
    { get { return _WitnessId; } }


    /// <summary>
    /// BT����p�̃p�����[�^�R���e�i
    /// </summary>
    private ParameterContainer _PC;

    /// <summary>
    /// �����o���̃e�L�X�g
    /// </summary>
    [SerializeField] private TextMeshProUGUI _BaroonText;

    /// <summary>
    /// �v�lFSM
    /// </summary>
    public Arbor.ArborFSM _ThinkFSM = null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();        
        // �p�����^�R���e�i�擾
        _PC = GetComponent<ParameterContainer>();
        // FSM�擾
        _ThinkFSM = GetComponent<Arbor.ArborFSM>();

        // �ؐl���X�g�Ɏ�����ǉ�
        WitnessManager.Instance.addWitness(this);

        // �����o���e�L�X�g
        _BaroonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ���̃p�[�g�̃A�N�V�������������Ă��邩�ǂ���
    /// </summary>
    /// <returns></returns>
    public bool isPartActionSuccess()
    {
        if(_PC == null)
        {
            Debug.Log("�p�����[�^�R���e�i��null");
            return false;
        }

        return _PC.GetBool("IsPartActionSuccess");
    }

    /// <summary>
    /// �p�[�g�����t���O�̃Z�b�g
    /// </summary>
    /// <param name="success"></param>
    public void setPartActionSuccess(bool success)
    {
        if (_PC == null)
        {
            Debug.Log("�p�����[�^�R���e�i��null");
        }

        _PC.SetBool("IsPartActionSuccess",success);

    }

    /// <summary>
    /// �v�lFSM�̍ĊJ�i���[�v���Z�b�g�A���p�[�g�ւ̑J�ڗp�j
    /// </summary>
    public void restartThinkFSM()
    {
        if(_ThinkFSM != null)
        {
            var state = _ThinkFSM.FindState("ActionStart");
            _ThinkFSM.Transition(state);
        }
    }

    /// <summary>
    /// �p�[�g���Ƃ̊J�n�ʒu�ɖ߂��i���[�v���Z�b�g�p�j
    /// </summary>
    /// <param name="part"></param>
    public override void resetPartTransform(int part)
    {
        // �Ƃ肠�����J�n���̍��W������
        // TODO�e�p�[�g�J�n�ʒu��ۑ����Ă����Ďw�肷��H
        var agent = GetComponent<NavMeshAgent>(); // �i�r�p�G�[�W�F���g�����Ă�ƍ��W�w��ړ����ł��Ȃ����Ƃ�����̂Ő؂��Đݒ�
        agent.enabled = false;
        transform.SetLocalPositionAndRotation(_PartStartPosList[part], transform.rotation);
        agent.enabled = true;
    }

    /// <summary>
    /// �p�[�g���w�肵�Đ����o���e�L�X�g�Z�b�g
    /// </summary>
    /// <param name="partNo"></param>
    public void setPartBaroonText(int partNo)
    {
        var testimonyData = WitnessManager.Instance.getTestimonyData(partNo, WitnessId);
        var text = "";
        if (testimonyData != null)
        {
            text = testimonyData.getTextimony();
        }
        setBaroonText(text);
    }


    /// <summary>
    /// �����o���̕��̓Z�b�g
    /// </summary>
    /// <param name="text"></param>
    private void setBaroonText(string text)
    {
        _BaroonText.text = text;
    }

}