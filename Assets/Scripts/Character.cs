using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour {

	public float health = 100f;
	public float maxHealth = 100f;
	public float healPerSecond = 0f;
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) Die();
		health = Mathf.Min(health + healPerSecond * Time.deltaTime, maxHealth);
	}

	public virtual void Die() {
		Destroy (this.gameObject);
	}
}
