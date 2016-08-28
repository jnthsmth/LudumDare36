using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = GameManager.instance.player.transform.position;
		pos.z = transform.position.z;
		transform.position = pos;

		transform.position = pos;

	}
}
