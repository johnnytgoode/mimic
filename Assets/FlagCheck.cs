using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class FlagCheck : Decorator {

	[SerializeField] EvidenceManager.EvidenceId _EvidenceId;

	protected override void OnAwake() {
	}

	protected override void OnStart() {
	}

	protected override bool OnConditionCheck() {		
		return LoopManager.Instance.isOnActionFlag(((int)_EvidenceId));
	}

	protected override void OnEnd() {
	}
}
