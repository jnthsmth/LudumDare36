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
	public float speedScale = 4f;
	private Rigidbody rig;
	public Vector3 jumpVector = new Vector3(0f,7f,0f);
	private bool jump = false;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
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
		Vector3 vel = rig.velocity;
		vel.x = Mathf.MoveTowards (vel.x, controlVector.x * speedScale, responsiveness.x);
		if (jump) {
			jump = false;
			vel += jumpVector;
		}
		rig.velocity = vel;
	}
}
