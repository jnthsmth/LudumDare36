using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class DartBehavior : MonoBehaviour {

	private Rigidbody rig;
	public float damage = 10f;
	public bool active = false;
	private bool wasActive = false;
	public float despawnTime = 10f;
	private bool despawn = false;
	private Vector3 velocity = Vector3.left;

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
		}else if(rig.velocity.magnitude > 3f && wasActive) {
			transform.rotation = Quaternion.AngleAxis(Vector3.Angle(Vector3.left, rig.velocity) * (rig.velocity.y > 0?-1f:1f), Vector3.forward);
			Activate(rig.velocity);
		}
		if(despawnTime <= 0) {
			Destroy(this.gameObject);
		}
	}

	void FixedUpdate() {
		if(active) {
			velocity += Physics.gravity * Time.deltaTime;
			rig.position += velocity * Time.deltaTime;
		}
		if(despawn) {
			despawnTime -= Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(active) {
			if(other.isTrigger) return;
			Character target = other.GetComponentInParent<Character>();
			if(target != null) target.health -= damage;
			rig.isKinematic = false;
			rig.useGravity = true;
			velocity = other.attachedRigidbody.velocity;
			Deactivate();
		}
	}

	public void Activate(Vector3 vel) {
		rig.isKinematic = true;
		rig.useGravity = false;
		velocity = vel;
		active = true;
		despawn = true;
	}

	public void Deactivate() {
		if(active = true) wasActive = true;
		active = false;
		rig.velocity = velocity;
	}
}
