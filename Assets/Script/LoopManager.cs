using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class LoopManager : SingletonMonoBehaviour<LoopManager>
{
    // �p�[�g��ł̌o�ߎ���
    [SerializeField]
    private float _LoopWaitTime = 0.0f;
    public float LoopWaitTime
    {
        get { return _LoopWaitTime; }
    }

    /// <summary>
    /// ���[�v�I���c�莞�Ԍv�Z�p
    /// </summary>
    private float _LoopPartRestTime = 0.0f;

    public float LoopPartRestTime
    {
        get{return _LoopPartRestTime;}
    }


    /// <summary>
    /// ���݂̃p�[�g
    /// </summary>
    public int _CurrentPart = 0;

    /// <summary>
    /// ���݂̃p�[�g�ԍ�����
    /// </summary>
    [SerializeField] GameObject[] PartNoGUIObj = new GameObject[2];

    private GUIPartNo[] _PartNoGUI = new GUIPartNo[2];

    //TODO: ���[�v�f�[�^�͎��O�ɍ�����f�[�^���X�g�����������Ă���悤�ɏC��
    public cLoopData _CurrentLoopData = new cLoopData();

    public enum State
    {
        Init,
        Instantiate,
        Instantiate_Wait,
        Init_Position,
        ActionStart,
        Wait,
        Finish,
    }

    /// <summary>
    /// ���
    /// </summary>
    private State _State = State.Init;

    /// <summary>
    /// �p�����[�^�R���e�i
    /// </summary>
    private Arbor.ParameterContainer _PT;


    public enum ActionFlag
    {
        C_Sabori,
        A_Kill,
        D_RoomChange,
    }


    // Start is called before the first frame update
    void Start()
    {
        _PT = GetComponent<Arbor.ParameterContainer>();
        _PartNoGUI[0] = PartNoGUIObj[0].GetComponent<GUIPartNo>();
        _PartNoGUI[1] = PartNoGUIObj[1].GetComponent<GUIPartNo>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_State) 
        {
            case State.Init:
                {
                    _State = State.Instantiate;

                    // ���ōő�l�ݒ�
                    _PartNoGUI[0].setPartNo(5);

                    break;
                }
            case State.Instantiate:
                {
                    //_WitnessInstance = Instantiate(WitnessPrefabList[0], Vector3.zero, Quaternion.identity);
                    _State = State.Instantiate_Wait;
                    break;
                }
            case State.Instantiate_Wait:
                {
                    //if (_WitnessInstance.activeSelf)
                    {
                        //var comp = _WitnessInstance.GetComponent<NavMeshController>();
                        //_Witnesses.Add(comp);

                        _State = State.Init_Position;
                    }
                    break;
                }
            case State.Init_Position:
                {

                    var currentLoop = _PT.GetInt("CurrentLoop");
                    _PartNoGUI[1].setPartNo(currentLoop);

                    // PL�̍��W�����Z�b�g
                    PlayerManager.Instance.resetPlayerPosition(currentLoop);
                    WitnessManager.Instance.resetPartStartTransform(currentLoop);

                    // �����o���e�L�X�g�ݒ�
                    WitnessManager.Instance.setBaroonText(currentLoop);

                    // �ĊJ������
                    WitnessManager.Instance.retartThinkFSM();


                    _State = State.ActionStart;
                    break;
                }
            case State.ActionStart:
                {
                    //foreach (var witness in _Witnesses)
                    //{
                    //    witness.enqueueActionState(new WitnessActionNavi(target.position));
                    //}
                    var currentLoop = _PT.GetInt("CurrentLoop");
                    _LoopPartRestTime = _CurrentLoopData.getLoopPartTime(currentLoop);
                    _State = State.Wait;
                    break;
                }
            case State.Wait:
                {
                    _LoopWaitTime += Time.deltaTime;
                    var currentLoop = _PT.GetInt("CurrentLoop");
                    float loopPartTime = _CurrentLoopData.getLoopPartTime(currentLoop);
                    _LoopPartRestTime = loopPartTime - _LoopWaitTime;
                    if (_LoopPartRestTime <= 0.0f)
                    {
                        bool success = WitnessManager.Instance.isAllWitnessPartActionSuccess();

                        if(success)
                        {
                            currentLoop++;
                            int partMax = 5;
                            if (partMax < currentLoop)
                            {
                                _State = State.Finish;
                                return;
                            }

                            _LoopWaitTime = 0.0f;
                            Debug.Log("�A�N�V���������B���̃p�[�g�Ɉڍs");

                            _PT.SetInt("CurrentLoop", currentLoop);

                            // ���[�v�J�n�ʒu�̍X�V
                            PlayerManager.Instance.setPlayerPartResetPos(currentLoop);
                            WitnessManager.Instance.setPartResetPos(currentLoop);



                        }
                        else
                        {
                            // �A�N�V�����������ĂȂ�������Z�b�g���Ȃ���
                            _LoopWaitTime = 0.0f;

                            Debug.Log("�A�N�V�������s�B�A�N�V�������[�v���܂�");

                        }

                        _State = State.Init_Position;

                    }

                    break;
                }
            case State.Finish:
                {
                    Debug.Log("�A�N�V��������");
                    break;
                }
        }
    }

    /// <summary>
    /// �w�肵���t���O�𗧂Ă�
    /// </summary>
    /// <param name="flag"></param>
    public void setActionFlag(bool flag)
    {
        // TODO:�t���OID���w��ł���悤�ɂ���
        _PT.SetBool("NextFlag", flag);
    }

    public void setActionFlag(int flag)
    {
        var actFlag = _PT.GetInt("ActionFlag");
        actFlag |= (1 << flag);
        _PT.SetInt("ActionFlag", actFlag);
    }

    public bool isOnActionFlag(int flag)
    {
        var actFlag = _PT.GetInt("ActionFlag");
        return (actFlag &= (1 << flag)) != 0 ;
    }
}
