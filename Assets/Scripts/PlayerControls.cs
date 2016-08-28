using UnityEngine;
using System.Collections;

public class PlayerControls : CharacterControls {
	public override void updateControls () {
		controlVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if(controlVector.magnitude != 0f) controlVector.Normalize();
		if (Input.GetKeyDown (KeyCode.W) && grounded) jump = true;
		if (Input.GetKeyDown (KeyCode.Space)) {
			Transform weapon = transform.FindChild ("BindableWeapon");
			if (weapon) {
				BlowgunBehavior[] guns = weapon.gameObject.GetComponentsInChildren<BlowgunBehavior>();
				foreach(BlowgunBehavior gun in guns) {
					gun.Fire();
				}
			}
		}
	}
}
