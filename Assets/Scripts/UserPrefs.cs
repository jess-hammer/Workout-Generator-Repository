using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserPrefs : MonoBehaviour
{
	public int difficulty = 3;
	public int duration = 15;
	public int warmup = 5;
	public int cooldown = 5;
	

	public bool upperFocus = true;
	public bool middleFocus = true;
	public bool lowerFocus = true;

	/*public void updateStringToValue(string str, int value)
	{
		if (str.Equals("difficulty")) {
			difficulty = value;
		} else if (str.Equals ("duration")) {
			duration = value;
		} else if (str.Equals ("warmup")) {
			warmup = value;
		} else if (str.Equals ("cooldown")) {
			cooldown = value;
		} else {
			Debug.Log ("Could not find " + str + " user pref to update");
		}
	}

	public int getValueFromString (string str)
	{
		if (str.Equals ("difficulty")) {
			return difficulty;
		} else if (str.Equals ("duration")) {
			return duration;
		} else if (str.Equals ("warmup")) {
			return warmup;
		} else if (str.Equals ("cooldown")) {
			return cooldown;
		} else {
			Debug.Log ("Could not find " + str + " user pref to get");
		}
		return -1;
	}


	public void updateStringToValue (string str, bool value)
	{
		if (str.Equals ("upperFocus")) {
			upperFocus = value;
		} else if (str.Equals ("middleFocus")) {
			middleFocus = value;
		} else if (str.Equals ("lowerFocus")) {
			lowerFocus = value;
		} else {
			Debug.Log ("Could not find " + str + " user pref to update");
		}
	}

	public bool getBoolValueFromString (string str)
	{
		if (str.Equals ("upperFocus")) {
			return upperFocus;
		} else if (str.Equals ("middleFocus")) {
			return middleFocus;
		} else if (str.Equals ("lowerFocus")) {
			return lowerFocus;
		} else {
			Debug.Log ("Could not find " + str + " user pref to get");
		}
		return false;
	}*/

	public void updateValue (PrefName pref, int value)
	{
		switch (pref) {
		case PrefName.Cooldown:
			cooldown = value;
			break;
		case PrefName.Difficulty:
			difficulty = value;
			break;
		case PrefName.Duration:
			duration = value;
			break;
		case PrefName.Warmup:
			warmup = value;
			break;
		default:
			Debug.Log ("Update failed");
			break;
		}
	}

	public void updateValue (PrefName pref, bool value)
	{
		switch (pref) {
		case PrefName.UpperFocus:
			upperFocus = value;
			break;
		case PrefName.MiddleFocus:
			middleFocus = value;
			break;
		case PrefName.LowerFocus:
			lowerFocus = value;
			break;
		default:
			Debug.Log ("Update failed");
			break;
		}
	}

	public int getValue (PrefName pref)
	{
		switch (pref) {
		case PrefName.Cooldown:
			return cooldown;
		case PrefName.Difficulty:
			return difficulty;
		case PrefName.Duration:
			return duration;
		case PrefName.Warmup:
			return warmup;
		default:
			Debug.Log ("Get value failed");
			break;
		}
		return -1;
	}


	public bool getBoolValue (PrefName pref)
	{
		switch (pref) {
		case PrefName.UpperFocus:
			return upperFocus;
		case PrefName.MiddleFocus:
			return middleFocus;
		case PrefName.LowerFocus:
			return lowerFocus;
		default:
			Debug.Log ("Get bool failed");
			break;
		}
		return true;
	}
}

public enum PrefName {
	Difficulty,
	Duration,
	Warmup,
	Cooldown,
	UpperFocus,
	MiddleFocus,
	LowerFocus
}
