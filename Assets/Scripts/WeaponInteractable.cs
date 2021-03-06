﻿using UnityEngine;
using System.Collections;

public class WeaponInteractable : Interactable {

	public override void Interact() {
		if (transform.parent == GameManager.instance.player.transform) {
			transform.parent = null;
			transform.FindChild("HitBox").gameObject.SetActive(true);
			GetComponent<Rigidbody> ().isKinematic = false;
		} else {
			transform.parent = GameManager.instance.player.transform;
			transform.localPosition = Vector3.zero;
			Quaternion rot = GameManager.instance.player.transform.rotation;
			rot.y += 180;
			transform.localRotation = rot;
			transform.FindChild("HitBox").gameObject.SetActive(false);
			GetComponent<Rigidbody> ().isKinematic = true;
		}
	}

}
