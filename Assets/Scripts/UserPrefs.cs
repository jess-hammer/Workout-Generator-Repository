using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;


public class UserPrefs : MonoBehaviour
{
	

	public int difficulty = 2;
	public int duration = 15;
	public int warmup = 5;
	public int cooldown = 5;
	public int totalDuration;

	public bool upperFocus = true;
	public bool middleFocus = true;
	public bool lowerFocus = true;

	public List<Equipment> equipment = new List<Equipment> ();
	public List<Type> workoutType = new List<Type> ();

	public NotificationManager myNotification​;

	private void Awake ()
	{
		totalDuration = duration + cooldown + warmup;

		equipment.Clear();
		workoutType.Clear ();

		equipment.Add (Equipment.NoEquipment);
		equipment.Add (Equipment.Dumbbells);

		workoutType.Add (Type.Cardio);
		workoutType.Add (Type.Strength);
	}

	public bool isValid()
	{
		if (!upperFocus && !middleFocus && !lowerFocus) {
			myNotification.description = "Please select at least one focus area";
			myNotification.OpenNotification ();
			return false;
		}

		if (equipment.Count <= 0) {
			myNotification.description = "Select at least one equipment option.\nSelect \"No Equipment\" if you wanted \nno equipment";
			myNotification.OpenNotification ();
			return false;
		}
		if (workoutType.Count <= 0) {
			myNotification.description = "Please select at least one workout type";
			myNotification.OpenNotification ();
			return false;
		}
		if (difficulty > 4 || difficulty < 0) {
			myNotification.description = "Not sure how you got here, but you \nhave an invalid difficulty";
			myNotification.OpenNotification ();
			return false;
		}
		if (duration < 0 || totalDuration < 0 || warmup < 0 || cooldown < 0) {
			myNotification.description = "Invalid duration! It should not \nbe negative";
			myNotification.OpenNotification ();
			return false;
		}
		return true;
	}

	public void randomise()
	{
		difficulty = UnityEngine.Random.Range (1, 6);
		duration = UnityEngine.Random.Range (15, 61);
		warmup = UnityEngine.Random.Range (5, 11);
		cooldown = UnityEngine.Random.Range (5, 11);

		if (duration < 20) {
			warmup = Mathf.Clamp (warmup, 0, 6);
		}
	}

	public string ListToString<T>(List<T> list)
	{
		string str = "";
		foreach (T item in list) {
			str += item + ", ";
		}

		if (str != "") {
			str = str.Remove (str.Length - 2);
		}
		return str;
	}

	public string focusAreaToString ()
	{
		if (upperFocus && middleFocus && lowerFocus) {
			return "Total Body";
		}

		string str = "";
		if (upperFocus) {
			str += "Upper Body, ";
		}
		if (middleFocus) {
			str += "Middle Body, ";
		}
		if (lowerFocus) {
			str += "Lower Body, ";
		}
		if (str != "") {
			str = str.Remove (str.Length - 2);
		}
		return str;
	}

	public string difficultyToString ()
	{
		switch (difficulty) {
		case 0:
			return "1 (Easy)";
		case 1:
			return "2 (Low Impact)";
		case 2:
			return "3 (Moderate)";
		case 3:
			return "4 (Tough)";
		case 4:
			return "5 (Challenging)";
		default:
			return "Invalid difficulty";
		}
	}

	public void updateValue (PrefName pref, int value)
	{
		switch (pref) {
		case PrefName.Cooldown:
			cooldown = value;
			totalDuration = duration + warmup + cooldown;
			break;
		case PrefName.Difficulty:
			difficulty = value;
			break;
		case PrefName.Duration:
			duration = Mathf.Clamp(value, 5, 60);
			totalDuration = duration + warmup + cooldown;
			break;
		case PrefName.Warmup:
			warmup = value;
			totalDuration = duration + warmup + cooldown;
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
		case PrefName.TotalDuration:
			return totalDuration;
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
	LowerFocus,
	TotalDuration
}
