using UnityEngine;
using System.Collections;

public class DoorAction : MachineAction {

	public Vector3 displacement = new Vector3(0f, 3f, 0f);
	bool open = false;

	public override void act() {
		obj.GetComponent<Rigidbody>().MovePosition(obj.transform.position + (open ? -displacement : displacement));
		open = !open;

		GameManager.instance.player.GetComponent<PlatformerControls> ().busy = false;
	}
}
