using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class UserPrefs
{
	public static int difficulty = 3;
	public static int duration = 15;
	public static int warmup = 5;
	public static int cooldown = 5;
	

	public static bool upperFocus = true;
	public static bool middleFocus = true;
	public static bool lowerFocus = true;

	public static void updateStringToValue(string str, int value)
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

	public static int getValueFromString (string str)
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


	public static void updateStringToValue (string str, bool value)
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

	public static bool getBoolValueFromString (string str)
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
	}
}
