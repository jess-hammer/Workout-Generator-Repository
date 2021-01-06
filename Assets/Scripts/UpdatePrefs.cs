using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePrefs : MonoBehaviour {
	public PrefName nameToUpdate;
	public UserPrefs userPrefs;

	private void Start ()
	{
		if (this.TryGetComponent<Slider> (out Slider slider)) {
			slider.value = userPrefs.getValue (nameToUpdate);
		} else if (this.TryGetComponent<Toggle> (out Toggle toggle)) {
			toggle.isOn = userPrefs.getBoolValue (nameToUpdate);
		} else if (this.TryGetComponent<Dropdown> (out Dropdown dropdown)) {
			dropdown.value = userPrefs.getValue (nameToUpdate);
		} else {
			Debug.Log (this.name + "is neither a toggle or slider lol");
		}
	}

	public void UpdatePref(float value)
	{
		userPrefs.updateValue (nameToUpdate, (int)value);
	}

	public void UpdatePref (int value)
	{
		userPrefs.updateValue (nameToUpdate, value);
	}
	public void UpdatePref (bool isOn)
	{
		userPrefs.updateValue (nameToUpdate, isOn);
	}

	
}
