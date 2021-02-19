using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeTextmeshToValue : MonoBehaviour
{
	private TextMeshProUGUI textBox;
	public string startString = "";
	public string endString = "";
	public PrefName nameToUpdate;
	private UserPrefs userPrefs;

	// Start is called before the first frame update
	void Start ()
	{
		textBox = GetComponent<TextMeshProUGUI> ();

		if (textBox == null) {
			Debug.Log ("textbox null");
		}

		userPrefs = GameObject.FindGameObjectWithTag ("System").GetComponent<UserPrefs> ();
		ChangeValue (userPrefs.getValue (nameToUpdate));
	}

	public void ChangeValue (Single value)
	{
		textBox.text = startString + (int)value + endString;
	}

	public void ChangeValue ()
	{
		textBox.text = startString + userPrefs.getValue (nameToUpdate) + endString;
	}
}
