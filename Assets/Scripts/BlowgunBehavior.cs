using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlowgunBehavior : MonoBehaviour {

	public float coolDown = 1f;
	private float timeLeft = 0f;
	public bool manualFire = false;
	public bool fullAuto = false;
	public float firingSpeed = 20f;
	public Transform dartFab = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fullAuto) manualFire = true;
		if(manualFire && timeLeft <= 0f) {
			manualFire = false;
			Fire();
		}
	}

	void FixedUpdate() {
		if(timeLeft > 0f) timeLeft -= Time.deltaTime;
		else if(timeLeft < 0f) timeLeft = 0f;
		if(timeLeft > coolDown) timeLeft = coolDown;
	}

	public void Fire() {
		if(timeLeft > 0f) return;
		timeLeft = coolDown;
		if(dartFab == null) return;

		int children = transform.childCount;
		int size = 0;
		List<Transform> spawnPoints = new List<Transform>();
		for(int i = 0; i< children; ++i) {
			if(transform.GetChild(i).name.Contains("Spawn Location")) {
				spawnPoints.Add(transform.GetChild(i));
				++size;
			}
		}

		if(size == 0) return;

		int shots = Random.Range(1, size);
		for(int i = 0; i < shots; ++i) {
			int child = Random.Range(0, size);
			Transform spawn = spawnPoints.ToArray()[child];
			Transform dart = (Transform) Instantiate(dartFab, spawn.position, transform.rotation);
			Rigidbody dartRig = dart.GetComponent<Rigidbody>();
			DartBehavior dartControl = dart.GetComponent<DartBehavior>();
			Vector3 vel = Vector3.ProjectOnPlane(dartRig.position - transform.position, transform.up);
			vel.Normalize();
			vel *= firingSpeed;
			dartControl.Activate(vel);
		}
	}

}
