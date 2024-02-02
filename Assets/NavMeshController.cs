using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class NavMeshController : Witness
{

    /// <summary>
    /// 行動の単位
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

    /// <summary>
    /// 登録されたアクションが終了したかどうか
    /// </summary>
    public bool IsActionEnd => _CurrentActionState == ActionState.Finish;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // Nav Mesh Agent を取得します。
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
    /// アクションの更新処理
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
    /// 座標セット
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
    /// 次のアクションをセット
    /// </summary>
    public bool setNextAction()
    {

        return false;
    }


}
