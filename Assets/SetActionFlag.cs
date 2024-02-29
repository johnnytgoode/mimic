using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class SetActionFlag : ActionBehaviour {

    [SerializeField] LoopManager.ActionFlag _ActionFlag;

    protected override void OnAwake() {
	}

	protected override void OnStart() {
	}

	protected override void OnExecute() {

		LoopManager.Instance.setActionFlag(((int)_ActionFlag));

        FinishExecute(true);
    }

    protected override void OnEnd() {
	}
}
