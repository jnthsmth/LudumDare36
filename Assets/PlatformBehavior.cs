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
	private float distance;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		start = rig.position;
		direction = (end - start);
		distance = direction.magnitude;
		direction.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
		if(activated) {
			move();
		} else {
			rig.velocity = new Vector3(0f, 0f);
		}
	}

	void FixedUpdate() {
		rig.position += rig.velocity * Time.deltaTime;
	}

	private void move() {
		checkDirection();
		rig.velocity = direction * speed;
	}

	private void checkDirection() {
		if(((rig.position-start).magnitude > distance && speed > 0) || ((rig.position-end).magnitude > distance && speed < 0)) {
			speed *= -1f;
		}
	}
}
