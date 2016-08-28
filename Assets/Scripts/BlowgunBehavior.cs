using UnityEngine;
using System.Collections;

public class BlowgunBehavior : MonoBehaviour {

	public float coolDown = 1f;
	public float timeLeft = 0f;
	private Rigidbody rig;
	public bool manualFire = false;
	public float firingSpeed = 20f;
	public bool fullAuto = false;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fullAuto) manualFire = true;
		if(manualFire && timeLeft <= 0f) {
			manualFire = false;
			Fire();
		}
	}

	void FixedUpdate() {
		if(timeLeft > 0f) timeLeft -= Time.deltaTime;
		else if(timeLeft < 0f) timeLeft = 0f;
	}

	void Fire() {
		if(timeLeft > 0f) return;
		timeLeft = coolDown;
		Vector3 pos = rig.position;

		Transform dart = (Transform) Instantiate(transform.FindChild("Dart"), transform.FindChild("Spawn Location").position, transform.rotation);
		Rigidbody dartRig = dart.GetComponent<Rigidbody>();
		DartBehavior dartControl = dart.GetComponent<DartBehavior>();

		Vector3 vel = (dartRig.position - transform.position);
		vel.Normalize();
		vel *= firingSpeed;
		dartControl.Activate(vel);
	}

}
