using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class EnemyControls : CharacterControls {

	public void Start() {
		controlVector.x = -1f;
	}

	public override void updateControls() {
		if (leftBlocked && !rightBlocked)
			controlVector.x = 1f;
		if (rightBlocked && !leftBlocked)
			controlVector.x = -1f;
	}

}
