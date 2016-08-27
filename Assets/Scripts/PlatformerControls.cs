using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlatformerControls : MonoBehaviour {

	public Vector2 controlVector = Vector2.zero;
	public bool grounded = true;
	public Vector2 speedLimits = new Vector2(10f, 10f);
	public float speed = 8f;
	public float accel = 80f;
	private Rigidbody rig;
	public Vector3 jumpVector = new Vector3(0f, 16f, 0f);
	private bool jump = false;
	public float friction = .1f;

	void Awake() {
		rig = GetComponent<Rigidbody>();
	}

	void Update () {
		controlVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (Input.GetKeyDown (KeyCode.Space) && grounded) jump = true;
		if(controlVector.x > 0) GetComponentInChildren<SpriteRenderer>().flipX = false;
		if(controlVector.x < 0) GetComponentInChildren<SpriteRenderer>().flipX = true;
	}

	void FixedUpdate() {
		checkGrounded ();
		Vector3 vel = rig.velocity;
		vel = applyControls(vel);
		vel = applySpeedLimits(vel);
		vel = applyFriction (vel);
		rig.velocity = vel;
	}

	void checkGrounded() {
		Vector3 down = transform.TransformDirection(Vector3.down);
		grounded = Physics.Raycast (transform.position, down, 1.3f);
	}

	bool checkSide(float x) {
		Vector3 left = transform.TransformDirection(Vector3.left);
		Vector3 right = transform.TransformDirection(Vector3.right);
		if(x > 0)
			return Physics.Raycast(transform.position, right, 1.3f) || 
				Physics.Raycast(transform.position + new Vector3(0f,0.65f,0f), right, 1.3f) || 
				Physics.Raycast(transform.position - new Vector3(0f,0.65f,0f), right, 1.3f);
		if(x < 0)
			return Physics.Raycast(transform.position, left, 1.3f) || 
				Physics.Raycast(transform.position + new Vector3(0f,0.65f,0f), left, 1.3f) || 
				Physics.Raycast(transform.position - new Vector3(0f,0.65f,0f), left, 1.3f);
		return false;
	}

	Vector3 applyControls(Vector3 vec) {
		if(checkSide(controlVector.x))
			controlVector.x = 0f;
		vec.x += controlVector.x * accel * Time.fixedDeltaTime;
		if (vec.x > speed) vec.x = speed;
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

	Vector3 applyFriction(Vector3 vec) {
		if (!grounded)
			return vec;
		float mag = Mathf.Abs(vec.x) - friction * Time.deltaTime;
		if (mag < 0f) mag = 0f;
		if (vec.x < 0f)
			mag = -mag;
		vec.x = mag;
		return vec;
	}

}
