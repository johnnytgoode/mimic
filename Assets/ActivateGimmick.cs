using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;

[AddComponentMenu("")]
public class ActivateGimmick : ActionBehaviour {

	[SerializeField]private GameObject _GimmickObject;
	private Gimmick _Gimmick;

	protected override void OnAwake() {
	}

	protected override void OnStart() {
		_GimmickObject.TryGetComponent<Gimmick>(out _Gimmick);
	}

	protected override void OnExecute() {
		_Gimmick.activateGimmick();
        FinishExecute(true);
    }

    protected override void OnEnd() {
	}
}
