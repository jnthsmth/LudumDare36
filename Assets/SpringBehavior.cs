using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SpringBehavior : MonoBehaviour {

	public bool activated = true;
	private Rigidbody rig;
	public float force = 50f;

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
		if(activated) {
			Rigidbody otherRig = other.gameObject.GetComponent<Rigidbody> ();
			otherRig.velocity += transform.up * force;
		}
	}
}
