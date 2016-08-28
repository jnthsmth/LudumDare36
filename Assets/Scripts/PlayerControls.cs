﻿using UnityEngine;
using System.Collections;

public class PlayerControls : CharacterControls {
	public override void updateControls () {
		controlVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if(controlVector.magnitude != 0f) controlVector.Normalize();
		if (Input.GetKeyDown (KeyCode.W) && grounded) jump = true;
	}
}
