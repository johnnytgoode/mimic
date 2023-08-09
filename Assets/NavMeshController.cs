using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class NavMeshController : Humanoid
{

    public Transform target;
    private NavMeshAgent myAgent;

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
        // target�Ɍ������Ĉړ����܂��B
        myAgent.SetDestination(target.position);
        
        if (_hasAnimator)
        {
            _animator.SetFloat(_animIDSpeed, myAgent.velocity.magnitude);
            _animator.SetFloat(_animIDMotionSpeed, 1);
        }

        myAgent.isStopped = true;


    }


}
