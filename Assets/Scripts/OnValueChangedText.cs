using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnValueChangedText : MonoBehaviour
{
	//private Text ValueText;
	public Text duration;
	public Text difficulty;

	private void Start ()
	{
		//ValueText = GetComponent<Text> ();
	}

	public void DurationSliderValueChanged (float value)
	{
		duration.text = "Duration: " + value.ToString () + " min";
		UserPrefs.durationMin = (int)value;
	}

	public void DifficultySliderValueChanged (float value)
	{
		difficulty.text = "Difficulty: " + value.ToString ();
		UserPrefs.difficulty = (int)value;
	}

	public void UpperToggle (bool isOn)
	{
		UserPrefs.upperFocus = isOn;
	}

	public void MiddleToggle (bool isOn)
	{
		UserPrefs.middleFocus = isOn;
	}

	public void LowerToggle (bool isOn)
	{
		UserPrefs.lowerFocus = isOn;
	}
}
