using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class DartBehavior : MonoBehaviour {

	private Rigidbody rig;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(rig.velocity);
	}

	void OnTriggerEnter(Collider other) {
		Destroy(this.gameObject);
	}


}
