using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Generator : MonoBehaviour
{
	public BaseExercise [] exercises = new BaseExercise [0];
	public float totalTimeLength = 0;
	public float totalTimeLeft = 0;
	private UserPrefs userPrefs;
	public int seed;
	

	public void Start ()
	{
		userPrefs = GetComponent<UserPrefs> ();
		seed = UnityEngine.Random.Range (-10000, 10000);
		UnityEngine.Random.InitState (seed);

		if (!Exercises.isInitalised) {
			Exercises.generateAllExerciseList ();
		}
	}

	// returns an array of excercises in random order
	public void CreateWorkout ()
	{
		// initalise variables
	    List<BaseExercise> exerciseSelection =  new List<BaseExercise> ();
		int timeLeft = userPrefs.duration  * 60; //converted to seconds
	  	BaseExercise [] options = Exercises.exercises;
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
	public bool alignment(BaseExercise exercise)
	{
		// check difficulty
		if (!(exercise.difficulty == userPrefs.difficulty ||
			exercise.difficulty == userPrefs.difficulty - 1)) { return false; }

		// check body focus
		if (userPrefs.upperFocus && exercise.isUpper) {
			return true;
		} else if (userPrefs.middleFocus && exercise.isMiddle) {
			return true;
		} else if (userPrefs.lowerFocus && exercise.isLower) {
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

	public string toString ()
	{
		string str = "";
		int n = exercises.Length;
		for (int i = 0; i < n; i++) {
			str += "\t" + (i + 1) + ") " + exercises [i].name + ". . . . ." + exercises [i].length + " sec\n";
		}
		return str;
	}
}