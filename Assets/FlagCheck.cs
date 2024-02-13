using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class FlagCheck : Decorator {

	[SerializeField]LoopManager.ActionFlag _ActionFlag;

	[SerializeField]FlexibleBool NotEqualFlag;

	protected override void OnAwake() {
	}

	protected override void OnStart() {
	}

	protected override bool OnConditionCheck() {		
		
		if(NotEqualFlag.value == true)
		{
            return !LoopManager.Instance.isOnActionFlag(((int)_ActionFlag));

        }
        return LoopManager.Instance.isOnActionFlag(((int)_ActionFlag));
	}

	protected override void OnEnd() {
	}
}
