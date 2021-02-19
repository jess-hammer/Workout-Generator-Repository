using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextToValue : MonoBehaviour
{
	private Text textBox;
	public string startString = "";
	public string endString = "";
	public PrefName nameToUpdate;
	private UserPrefs userPrefs;

    // Start is called before the first frame update
    void Start()
    {
		textBox = GetComponent<Text> ();

		userPrefs = GameObject.FindGameObjectWithTag ("System").GetComponent<UserPrefs> ();
		ChangeValue (userPrefs.getValue(nameToUpdate));
    }

    public void ChangeValue(Single value)
	{
		textBox.text = startString + " " + value + " " + endString;
	}

	public void ChangeValue()
	{
		textBox.text = startString + "\n" + userPrefs.getValue (nameToUpdate) + " " + endString;
	}
}
