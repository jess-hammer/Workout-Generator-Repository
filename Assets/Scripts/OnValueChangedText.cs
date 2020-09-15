using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnValueChangedText : MonoBehaviour
{
	//private Text ValueText;
	public Text duration;
	public Text difficulty;
	public Toggle upperFocus;
	public Toggle middleFocus;
	public Toggle lowerFocus;

	private void Start ()
	{
		//ValueText = GetComponent<Text> ();
	}

	public void OnSliderValueChanged (float value)
	{
		//ValueText.text = value.ToString ("0.00");
	}
}
