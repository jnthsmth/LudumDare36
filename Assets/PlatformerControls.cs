using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlatformerControls : MonoBehaviour {

	public Vector2 controlVector = Vector2.zero;
	public bool grounded = true;
	public float jumpResetTime = 0f;
	public float jumpTimer = 0f;
	public float horizontalControlSnap = 10f;
	public Vector2 responsiveness = new Vector2 (10f, 0f);
	public Vector2 speedLimits = new Vector2(10f, 10f);
	public float speedScale = 4f;
	private Rigidbody rig;
	public Vector3 jumpVector = new Vector3(0f,7f,0f);
	private bool jump = false;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	void Update () {
		jumpTimer -= Time.deltaTime;
		if (jumpTimer <= 0f) jumpTimer = 0f;
		controlVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (Input.GetKeyDown (KeyCode.Space) && grounded && jumpTimer == 0f) {
			jumpTimer = jumpResetTime;
			jump = true;
		}
	}

	void FixedUpdate() {
		checkGrounded ();
		Vector3 vel = rig.velocity;
		vel = applyControls(vel);
		vel = applySpeedLimits(vel);
		rig.velocity = vel;
	}

	void checkGrounded() {
		Vector3 down = transform.TransformDirection(Vector3.down);
		grounded = Physics.Raycast (transform.position, down, 1.3f);
	}

	Vector3 applyControls(Vector3 vec) {
		vec.x = Mathf.MoveTowards (vec.x, controlVector.x * speedScale, responsiveness.x);
		if (jump) {
			jump = false;
			vec += jumpVector;
		}
		return vec;
	}

	Vector3 applySpeedLimits(Vector3 vec) {
		if (vec.x > 0) vec.x = Mathf.Min (vec.x, speedLimits.x);
		else vec.x = Mathf.Max (vec.x, -speedLimits.x);
		if (vec.y > 0) vec.y = Mathf.Min (vec.y, speedLimits.y);
		else vec.y = Mathf.Max (vec.y, -speedLimits.y);
		return vec;
	}

}
