using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterControls))]
public class CharacterMotion : MonoBehaviour {

	public float speedLimit = 15f;
	public float speed = 8f;
	public float accel = 80f;
	public float jumpForce = 16f;
	public float friction = .1f;

	public CharacterControls controls;
	public Rigidbody rig;

	void Awake() {
		controls = GetComponent<CharacterControls>();
		rig = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		
		Vector3 rot = transform.rotation.eulerAngles;
		rot.y = controls.facingLeft ? 180f : 0f;
		transform.rotation = Quaternion.Euler (rot);

		Vector3 vel = rig.velocity;
		if(!controls.groundedLastFrame && controls.grounded && vel.y < 0) vel.y = 0;
		vel = applyControls(vel);
		vel = applySpeedLimits(vel);
		vel = applyFriction (vel);
		rig.velocity = vel;
	}

	Vector3 applyControls(Vector3 vec) {
		if(!((controls.leftBlocked && controls.controlVector.x < 0f || controls.rightBlocked && controls.controlVector.x > 0f) && !controls.grounded))
			vec.x += controls.controlVector.x * accel * Time.fixedDeltaTime;
		if (Mathf.Abs(vec.x) > speed) vec.x = vec.x > 0 ? speed:-speed;
		if (controls.jump) {
			controls.jump = false;
			vec.y += jumpForce;
		}
		return vec;
	}

	Vector3 applySpeedLimits(Vector3 vec) {
		return (vec.magnitude > speedLimit) ? vec.normalized * speedLimit : vec;
	}

	Vector3 applyFriction(Vector3 vec) {
		if (!controls.grounded)
			return vec;
		float mag = Mathf.Abs(vec.x) - friction * Time.deltaTime;
		if (mag < 0f) mag = 0f;
		if (vec.x < 0f) mag = -mag;
		vec.x = mag;
		return vec;
	}

}
