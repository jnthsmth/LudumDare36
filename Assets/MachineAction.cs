using UnityEngine;
using System.Collections;

public class MachineAction : MonoBehaviour {

	public GameObject obj;

	public virtual void act() {
		print ("TRIGGERED");
	}

	void Start() {
		obj = transform.parent.FindChild ("Object").gameObject;
	}


}
