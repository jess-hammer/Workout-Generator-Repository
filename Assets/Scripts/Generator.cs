using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class Generator
{
	public static int seed;
	public static List<BaseExercise> exerciseSelection = new List<BaseExercise> ();
	public static BaseExercise [] exercises = new BaseExercise [0];
	public static Exercises exerciseClass = new Exercises ();
	

	// returns an array of excercises in random order
	public static void CreateWorkout ()
	{
		ImplementWorkout.index = 0;
		seed = (int)UnityEngine.Random.Range (-10000, 10000);
		UnityEngine.Random.InitState (seed);
		exerciseSelection = new List<BaseExercise>();

		// select exercise that align with the user prefs
		foreach (BaseExercise ex in Exercises.exercises) {
			if (alignment(ex)) {
				exerciseSelection.Add (ex);
			}
		}

		// convert to array and shuffle the order
		var exArray = exerciseSelection.ToArray ();
		ShuffleArray (exArray);
		exercises = exArray;

		if (exercises.Length > 0) {
			ImplementWorkout.isGenerated = true;
		}
	}

	// returns true if exercise matches the user prefs
	public static bool alignment(BaseExercise exercise)
	{
		return true;
	}

	static void ShuffleArray<T> (T [] array)
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