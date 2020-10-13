using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePrefs : MonoBehaviour {
	public string nameToUpdate;

	private void Start ()
	{
		if (this.TryGetComponent<Slider> (out Slider slider)) {
			slider.value = UserPrefs.getValueFromString (nameToUpdate);
		} else if (this.TryGetComponent<Toggle> (out Toggle toggle)) {
			toggle.isOn = UserPrefs.getBoolValueFromString (nameToUpdate);
		} else {
			Debug.Log (this.name + "is neither a toggle or slider lol");
		}
	}

	/*public void resetDisplay ()
	{
		if (this.TryGetComponent<Slider> (out Slider slider)) {
			if (nameToUpdate.Equals ("difficulty")) {
				slider.value = UserPrefs.difficulty;
			} else if (nameToUpdate.Equals ("duration")) {
				slider.value = UserPrefs.duration;
			} else if (nameToUpdate.Equals ("warmup")) {
				slider.value = UserPrefs.warmup;
			} else if (nameToUpdate.Equals ("cooldown")) {
				slider.value = UserPrefs.cooldown;
			} else {
				Debug.Log ("Could not find " + this.name + " slider value to refresh");
			}
		} else if (this.TryGetComponent<Toggle> (out Toggle toggle)) {
			if (nameToUpdate.Equals ("upperFocus")) {
				toggle.isOn = UserPrefs.upperFocus;
			} else if (nameToUpdate.Equals ("middleFocus")) {
				toggle.isOn = UserPrefs.middleFocus;
			} else if (nameToUpdate.Equals ("lowerFocus")) {
				toggle.isOn = UserPrefs.lowerFocus;
			} else {
				Debug.Log ("Could not find " + this.name + " toggle to refresh");
			}
		} else {
			Debug.Log (this.name + "is neither a toggle or slider lol");
		}
	}*/

	public void UpdatePref(float value)
	{
		UserPrefs.updateStringToValue (nameToUpdate, (int)value);
	}
	public void UpdatePref (bool isOn)
	{
		UserPrefs.updateStringToValue (nameToUpdate, isOn);
	}

	/*public void ChangeDifficulty (float value)
	{
		UserPrefs.difficulty = (int)value;
	}

	public void ChangeDuration (float value)
	{
		UserPrefs.duration = (int)value;
	}

	public void ChangeWarmup (float value)
	{
		UserPrefs.warmup = (int)value;
	}

	public void ChangeCooldown (float value)
	{
		UserPrefs.cooldown = (int)value;
	}*/

	/*public void ChangeUpperToggle (bool isOn)
	{
		UserPrefs.upperFocus = isOn;
	}

	public void ChangeMiddleToggle (bool isOn)
	{
		UserPrefs.middleFocus = isOn;
	}

	public void ChangeLowerToggle (bool isOn)
	{
		UserPrefs.lowerFocus = isOn;
	}*/
}
