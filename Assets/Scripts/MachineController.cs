using UnityEngine;
using System.Collections;

public class MachineController : MonoBehaviour {

	public Transform obj = null;
	public Transform ar = null;
	private ObjectsInRegion triggerList = null;
	private MachineAction action = null;

	// Use this for initialization
	void Start () {
		obj = transform.FindChild ("Object");
		ar = transform.FindChild ("ActiveRegion");
		if (!obj || !ar) {
			Debug.Log ("improperly formed machine");
			Destroy (this.gameObject);
		}
		triggerList = ar.GetComponent<ObjectsInRegion>();
		action = obj.gameObject.GetComponent<MachineAction> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && triggerList.value.Contains (GameManager.instance.player)) {
			action.act ();
		}
	}
}
