using UnityEngine;
using System.Collections;

public class ZombieClaws : MonoBehaviour {
	public float pushFactor = 10f;
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.GetComponent<PlatformerControls> () != null) {
			Character player = other.gameObject.GetComponent<Character> ();
			player.health -= 10;
			Rigidbody rig = other.gameObject.GetComponent<Rigidbody> ();
			rig.AddForce (pushFactor * (other.transform.position - transform.position), ForceMode.Impulse);
		}
	}
}
