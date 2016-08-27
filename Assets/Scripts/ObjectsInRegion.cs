using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//http://answers.unity3d.com/questions/638319/getting-a-list-of-colliders-inside-a-trigger.html

public class ObjectsInRegion : MonoBehaviour {

	List<GameObject> objs = new List<GameObject>();
	public int n = 0;

	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}

	void OnTriggerEnter(Collider other) {
		if (!objs.Contains (other.gameObject)) objs.Add (other.gameObject);
	}

	//void OnTriggerExit(Collider other) {
	//	while (objs.Contains (other.gameObject)) objs.Remove(other.gameObject);
	//}

	public List<GameObject> value {
		get { return objs; }
	}

	void Update() {
		n = objs.Count;
	}

}
