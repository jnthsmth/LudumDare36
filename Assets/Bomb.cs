using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bomb : MonoBehaviour {

	public bool active = true;
	public float timer = 5f;
	public float blastStrength = 50f;
	public Vector3 expand = new Vector3(35f,35f,35f);
	public Transform blast = null;
	public int n = 0;
	private ObjectsInRegion triggerList = null;
	private Rigidbody rig;

	void Awake() {
		rig = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
		blast = transform.FindChild ("Blast");
		blast.GetComponent<SphereCollider>().bounds.Expand(expand);
		triggerList = blast.GetComponent<ObjectsInRegion>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if(timer > 0f) {
			timer -= Time.deltaTime;
			if(timer < 0f) {
				timer = 0f;
			}
		} else {
			Blow();
		}
	}

	void Blow() {
		n = triggerList.value.ToArray().Length;
		for(int i = 0; i < n; ++i) {
			Rigidbody obRig = triggerList.value.ToArray()[i].GetComponent<Rigidbody>();
			obRig.AddExplosionForce(blastStrength,rig.position,expand);
		}
	}

}
