using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SpringBehavior : MonoBehaviour {

	private Rigidbody rig;
	public float force = 2f;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		Rigidbody otherRig = other.gameObject.GetComponent<Rigidbody> ();
		otherRig.velocity += transform.up * force;
	}
}
