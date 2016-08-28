using UnityEngine;
using System.Collections;

public class ZombieClaws : MonoBehaviour {
	public float pushFactor = 10f;
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.GetComponent<CharacterMotion> () != null) {
			Character ch = other.gameObject.GetComponent<Character>();
			if (ch)	ch.health -= 10f;
			Rigidbody rig = other.gameObject.GetComponent<Rigidbody> ();
			if (rig) rig.AddForce (pushFactor * (other.transform.position - transform.position).normalized, ForceMode.Impulse);
		}
	}
}
