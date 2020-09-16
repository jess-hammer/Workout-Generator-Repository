using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnValueChangedText : MonoBehaviour
{
	//private Text ValueText;
	public Text duration;
	public Text difficulty;

	[Space]
	public Slider durationSlider;
	public Slider difficultySlider;

	[Space]
	public Toggle upperToggle;
	public Toggle middleToggle;
	public Toggle lowerToggle;

	private void Start ()
	{
		resetDisplay ();

	}

	public void resetDisplay()
	{
		duration.text = "Duration: " + UserPrefs.durationMin + " min";
		difficulty.text = "Difficulty: " + UserPrefs.difficulty;
		durationSlider.value = UserPrefs.durationMin;
		difficultySlider.value = UserPrefs.difficulty;

		upperToggle.isOn = UserPrefs.upperFocus;
		middleToggle.isOn = UserPrefs.middleFocus;
		lowerToggle.isOn = UserPrefs.lowerFocus;
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
