using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class ActivateRefGameObject : ActionBehaviour {

	[SerializeField] GameObject _RefGameObject;

	protected override void OnAwake() {
	}

	protected override void OnStart() {
		// 起動する
		_RefGameObject.SetActive(true);
	}

	protected override void OnExecute() {
        FinishExecute(true);
    }

    protected override void OnEnd() {
	}
}
