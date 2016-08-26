using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SpinObject : MonoBehaviour {

	public float speed = 4f;

	void Start () {
		GetComponent<Rigidbody>().angularDrag = 0.0f;
		GetComponent<Rigidbody>().angularVelocity = Random.onUnitSphere * speed;
	}
}
