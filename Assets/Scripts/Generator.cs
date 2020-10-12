using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class Generator
{
	public static BaseExercise [] exercises = new BaseExercise [0];
	public static float totalTimeLength = 0;
	public static float totalTimeLeft = 0;

	// returns an array of excercises in random order
	public static void CreateWorkout ()
	{
		// initalise variables
		List<BaseExercise> exerciseSelection = new List<BaseExercise> ();
		int timeLeft = UserPrefs.duration  * 60; //converted to seconds
		BaseExercise [] options = Exercises.generateAllExerciseList();
		int i = 0;

		// safeguard
		if (options.Length == 0) {
			Debug.Log ("Error - there are no options to choose from");
		}

		// select exercise that align with the user prefs
		while (timeLeft > 0) {
			if (alignment(options[i])) {
				exerciseSelection.Add (options[i]);
				int amount = options [i].length + options [i].restLength;
				timeLeft -= amount;
				totalTimeLength += amount + 2;
			}

			// loop back around
			if (i == options.Length - 1) {
				i = -1;
			}
			i++;
		}

		// convert to array and shuffle the order
		var exArray = exerciseSelection.ToArray ();
		ShuffleArray (exArray); // not sure if really need to reshuffle
		exercises = exArray;
		totalTimeLeft = totalTimeLength;
	}

	// returns true if exercise matches the user prefs
	public static bool alignment(BaseExercise exercise)
	{
		// check difficulty
		if (!(exercise.difficulty == UserPrefs.difficulty ||
			exercise.difficulty == UserPrefs.difficulty - 1)) { return false; }

		// check body focus
		if (UserPrefs.upperFocus && exercise.isUpper) {
			return true;
		} else if (UserPrefs.middleFocus && exercise.isMiddle) {
			return true;
		} else if (UserPrefs.lowerFocus && exercise.isLower) {
			return true;
		} else {
			return false;
		}

	}

	public static void ShuffleArray<T> (T [] array)
	{
		int n = array.Length;
		for (int i = 0; i < n; i++) {
			// Pick a new index higher than current for each item in the array
			int r = i + UnityEngine.Random.Range (0, n - i);

			// Swap item into new spot
			T t = array [r];
			array [r] = array [i];
			array [i] = t;
		}
	}

	// prints exercises to the log for debug purposes
	public static void printExercises (BaseExercise [] array)
	{
		string str = "";
		for (int i = 0; i < array.Length; i++) {
			str += array [i].name + ", ";
		}
		Debug.Log (str);
	}

	public static string toString ()
	{
		string str = "";
		int n = exercises.Length;
		for (int i = 0; i < n; i++) {
			str += "\t" + (i + 1) + ". " + exercises [i].name + "...." + exercises [i].length + " sec\n";
		}
		return str;
	}
}