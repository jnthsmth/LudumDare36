using UnityEngine;
using System.Collections;

public class MachineAction : MonoBehaviour {

	public GameObject obj;

	public virtual void act() {
		print ("TRIGGERED");
		GameManager.instance.player.GetComponent<PlatformerControls> ().busy = false;
	}

	void Start() {
		obj = transform.parent.FindChild ("Object").gameObject;
	}


}
