using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class DartBehavior : MonoBehaviour {

	private Rigidbody rig;
	public float damage = 10f;

	void Awake() {
		rig = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.AngleAxis(Vector3.Angle(Vector3.left, rig.velocity), Vector3.forward);
	}

	void OnTriggerEnter(Collider other) {
		Character target = other.GetComponentInParent<Character>();
		if(target != null) target.health -= damage;
		Destroy(this.gameObject);
	}


}
