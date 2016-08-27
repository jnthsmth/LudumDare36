using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NPCDialog {
	public string optionDescription = "Talk";
	public string message = "Hello World!";
	public int[] subOptions = null;
}

public class DialogTraverse : MonoBehaviour {
	/*
	public NPCDialog[] dialogs;
	private int _selectedIdx = 0;
	private int selectedIdx {
		get { return _selectedIdx; }
		set { selectedIdx = value % root.subOptions.Length;
			setDisplayText(); }
	}

	void setDisplayText () {
		string displayText = selectedNode.message;
		for (int i = 0; i < selectedNode.subOptions.Length; i++) {
			displayText += "\n" + ((i == selectedIdx) ? ">" : "") + selectedNode.subOptions [i].optionDescription;
		}
		GetComponent<TextMesh> ().text = displayText;
	}

	void Start() {
		setDisplayText();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow)) selectedIdx++;
		else if (Input.GetKeyDown (KeyCode.UpArrow)) selectedIdx--;
	}
*/
}
