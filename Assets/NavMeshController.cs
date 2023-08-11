using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class NavMeshController : Witness
{

    /// <summary>
    /// �s���̒P��
    /// </summary>
    public enum ActionState
    {
        Idle,
        SetAction,
        FinishCheck,
        Navi,
        Motion,
        Finish,
    }

    private ActionState _CurrentActionState = ActionState.Idle;

    public Transform target;
    private NavMeshAgent myAgent;


    Queue<LoopManager.WitnessAction> _ActionQueue = new Queue<LoopManager.WitnessAction>();

    /// <summary>
    /// �o�^���ꂽ�A�N�V�������I���������ǂ���
    /// </summary>
    public bool IsActionEnd => _CurrentActionState == ActionState.Finish;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // Nav Mesh Agent ���擾���܂��B
        myAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        updateAction();
       
        if (_hasAnimator)
        {
            _animator.SetFloat(_animIDSpeed, myAgent.velocity.magnitude);
            _animator.SetFloat(_animIDMotionSpeed, 1);
        }
    }


    /// <summary>
    /// �A�N�V�����̍X�V����
    /// </summary>
    private void updateAction()
    {
        switch(_CurrentActionState)
        {
            case ActionState.Idle:
                {
                    break;
                }
            case ActionState.Navi:
                {
                    if(myAgent.velocity.sqrMagnitude <= 0.0f)
                    {
                    }
                    break;
                }
            case ActionState.Motion: 
                {

                    break;
                }
            case ActionState.FinishCheck:
                {
                    if(setNextAction() == false)
                    {
                        _CurrentActionState = ActionState.Finish;

                    }

                    break;
                }
            case ActionState.Finish:
                {
                    break;
                }
        }

    }

    /// <summary>
    /// ���W�Z�b�g
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="quat"></param>
    public void setTransform(Vector3 pos,  Quaternion quat)
    {
        myAgent.ResetPath();

        myAgent.isStopped = true; 

        transform.localPosition = pos;
        transform.localRotation = quat;
    }

    /// <summary>
    /// �A�N�V�����̃��Z�b�g
    /// </summary>
    public void resetAction()
    {
        _ActionQueue.Clear();
    }

    /// <summary>
    /// �s���̃Z�b�g
    /// </summary>
    public void enqueueActionState(LoopManager.WitnessAction action)
    {
        _ActionQueue.Enqueue(action);
        _CurrentActionState = ActionState.FinishCheck;

    }

    /// <summary>
    /// ���̃A�N�V�������Z�b�g
    /// </summary>
    public bool setNextAction()
    {
        var action = _ActionQueue.Dequeue();
        if(action == null)
        {
            return false;
        }

        switch (action.ActionType)
        {
            // �i�r�A�N�V�����o�^
            case LoopManager.WitnessAction.WitnessActionType.Navi:
                {
                    var naviAction = action as LoopManager.WitnessActionNavi;
                    if (naviAction != null)
                    {
                        // target�Ɍ������Ĉړ����܂��B
                        myAgent.SetDestination(naviAction.TargetPosition);
                        myAgent.isStopped = false ;
                        _CurrentActionState = ActionState.Navi;
                    }
                    return true;
                }
        }
        return false;
    }


}
