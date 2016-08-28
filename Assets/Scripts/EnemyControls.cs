using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectsInRegion))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyControls : CharacterControls {

	public ObjectsInRegion visionCone;
	public bool grounded = false;
	float baseSpeed;

	void Awake () {
		visionCone = GetComponent<ObjectsInRegion> ();
	}

	public override void updateControls() {
		if (leftBlocked && !rightBlocked)
			controlVector.x = 1f;
		if (rightBlocked && !leftBlocked)
			controlVector.x = -1f;
	}

}
