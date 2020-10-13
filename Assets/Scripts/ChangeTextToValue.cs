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
	public string nameToUpdate;

    // Start is called before the first frame update
    void Start()
    {
		textBox = GetComponent<Text> ();
		ChangeValue (UserPrefs.getValueFromString(nameToUpdate));
    }

    public void ChangeValue(Single value)
	{
		textBox.text = startString + " " + value + " " + endString;
	}
}
