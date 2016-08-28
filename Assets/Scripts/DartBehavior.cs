using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class DartBehavior : MonoBehaviour {

	private Rigidbody rig;
	public float damage = 10f;
	public bool active = false;
	public float despawnTime = 10f;
	private Vector3 velocity;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(active) {
			transform.rotation = Quaternion.AngleAxis(Vector3.Angle(Vector3.left, velocity) * (velocity.y > 0?-1f:1f), Vector3.forward);
			if(despawnTime <= 0) {
				Destroy(this.gameObject);
			}
		}
	}

	void FixedUpdate() {
		if(active) {
			velocity += Physics.gravity * Time.deltaTime;
			rig.position += velocity * Time.deltaTime;
			despawnTime -= Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(active) {
			Character target = other.GetComponentInParent<Character>();
			if(target != null) target.health -= damage;
			Destroy(this.gameObject);
		}
	}

	public void Activate(Vector3 vel) {
		rig.useGravity = true;
		velocity = vel;
		active = true;
	}

	public void Deactivate() {
		active = false;
		rig.useGravity = false;
	}
}
