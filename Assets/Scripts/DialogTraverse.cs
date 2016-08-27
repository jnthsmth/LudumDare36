using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NPCDialog {
	public string optionDescription = "Talk";
	public string message = "Hello World!";
	public int[] subOptions = null;
}

[RequireComponent(typeof(ObjectsInRegion))]
public class DialogTraverse : MonoBehaviour {
	
	public NPCDialog[] dialogs;

	private int currentDialogIdx = 0;
	private int selectionIdx {
		get { 
			if (currentDialog.subOptions.Length == 0) return 0;
			_selectionIdx %= currentDialog.subOptions.Length;
			return _selectionIdx;
		}
		set {
			if (value < 0) value = currentDialog.subOptions.Length - 1;
			if (currentDialog.subOptions.Length == 0) return;
			_selectionIdx = value % currentDialog.subOptions.Length;
			setDisplayText ();
		}
	}

	private NPCDialog currentDialog {
		get { return dialogs [currentDialogIdx]; }
	}

	private int _selectionIdx = 0;

	void setDisplayText () {
		string displayText = currentDialog.message;
		for (int i = 0; i < currentDialog.subOptions.Length; i++) {
			int subOptionIdx = currentDialog.subOptions[i];
			NPCDialog subOption = dialogs[subOptionIdx];
			displayText += "\n" + ((i == selectionIdx) ? ">" : "") + subOption.optionDescription;
		}
		GetComponent<TextMesh>().text = displayText;
	}

	void Start() {
		setDisplayText();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow)) selectionIdx++;
		else if (Input.GetKeyDown (KeyCode.UpArrow)) selectionIdx--;
		if (Input.GetKeyDown (KeyCode.E) && GetComponent<ObjectsInRegion>().value.Contains(GameManager.instance.player)) {
			currentDialogIdx = currentDialog.subOptions [selectionIdx];
			setDisplayText ();
		}
	}
}
