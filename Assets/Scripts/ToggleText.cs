using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleText : MonoBehaviour {

	public Text field;

	public void toggle(string msg) {
		field.text = msg;
	}
}
