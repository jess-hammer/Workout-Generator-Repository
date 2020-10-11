using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnValueChangedText : MonoBehaviour
{
	public Text difficulty;
	public Text duration;
	public Text warmup;
	public Text cooldown;

	[Space]
	public Slider difficultySlider;
	public Slider durationSlider;
	public Slider warmupSlider;
	public Slider cooldownSlider;

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
		// update text display
		difficulty.text = "Difficulty: " + UserPrefs.difficulty;
		duration.text = "Total Duration: " + UserPrefs.duration + " min";
		warmup.text = "Warmup: " + UserPrefs.duration + " min";
		cooldown.text = "Cooldown: " + UserPrefs.duration + " min";

		// update value of sliders
		difficultySlider.value = UserPrefs.difficulty;
		durationSlider.value = UserPrefs.duration;
		warmupSlider.value = UserPrefs.duration;
		cooldownSlider.value = UserPrefs.duration;


		upperToggle.isOn = UserPrefs.upperFocus;
		middleToggle.isOn = UserPrefs.middleFocus;
		lowerToggle.isOn = UserPrefs.lowerFocus;
	}

	public void DifficultySliderValueChanged (float value)
	{
		difficulty.text = "Difficulty: " + value.ToString ();
		UserPrefs.difficulty = (int)value;
	}

	public void DurationSliderValueChanged (float value)
	{
		duration.text = "Total Duration: " + value.ToString () + " min";
		UserPrefs.duration = (int)value;
	}

	public void WarmupSliderValueChanged (float value)
	{
		duration.text = "Warmup: " + value.ToString () + " min";
		UserPrefs.warmup = (int)value;
	}

	public void CooldownSliderValueChanged (float value)
	{
		duration.text = "Cooldown: " + value.ToString () + " min";
		UserPrefs.cooldown = (int)value;
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
