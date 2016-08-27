using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager _instance;
	public static GameManager instance {
		get { return _instance; }
		set {
			if (!_instance) _instance = value;
			else Destroy(value.gameObject);
		}
	}

	void Awake() {
		instance = this;
	}

	public GameObject player;
}
