using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlatformBehavior : MonoBehaviour {

	private Rigidbody rig;
	public bool activated = false;
	public float speed = 2f;
	public Vector3 start;
	public Vector3 end;
	private Vector3 direction;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		start = rig.position;
		direction = (end - start);
		direction.Normalize();
		rig.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(activated) {
			rig.isKinematic = false;
			move();
		} else {
			rig.isKinematic = true;
			rig.velocity = new Vector3(0f, 0f, 0f);
		}
	}

	void FixedUpdate() {
		//rig.position += rig.velocity * Time.deltaTime;

	}

	private void move() {
		checkDirection();
		rig.velocity = direction * speed;
	}

	private void checkDirection() {
		float distance = (end - start).magnitude;
		if(((rig.position-start).magnitude > distance && speed > 0) || ((rig.position-end).magnitude > distance && speed < 0)) {
			speed *= -1f;
		}
		if(speed > 0)
			direction = (end - rig.position);
		else if(speed < 0)
			direction = (rig.position - start);
		direction.Normalize();
	}

}
