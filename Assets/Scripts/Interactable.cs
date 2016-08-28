using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectsInRegion))]
public class Interactable : MonoBehaviour {

	public ObjectsInRegion oir;

	void Awake() {
		oir = GetComponent<ObjectsInRegion> ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.E) && oir.value.Contains (GameManager.instance.player)) Interact ();
	}

	public virtual void Interact() {}
}
