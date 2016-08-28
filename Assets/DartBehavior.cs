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
		transform.rotation = Quaternion.Euler(rig.velocity);
		transform.FindChild("Sprite").transform.rotation = transform.rotation;
	}

	void UpdateFixed() {
		transform.rotation = Quaternion.Euler(rig.velocity);
		transform.FindChild("Sprite").transform.rotation = transform.rotation;
	}

	void OnTriggerEnter(Collider other) {
		Destroy(this.gameObject);
	}


}
