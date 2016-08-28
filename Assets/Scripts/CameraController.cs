using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Rigidbody rig;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		Vector3 pos = GameManager.instance.player.transform.position;
		pos.z = transform.position.z;
		transform.position = pos;

	}
}
