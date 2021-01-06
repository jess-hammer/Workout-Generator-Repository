using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Generator : MonoBehaviour
{
	public BaseExercise [] warmupExercises;
	public BaseExercise [] exercises;
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
		warmupExercises = GenerateFromList (Exercises.warmupExercises, userPrefs.warmup);
		exercises = GenerateFromList (Exercises.exercises, userPrefs.duration);
	}


	private BaseExercise [] GenerateFromList(BaseExercise [] options, int length)
	{
		// initalise variables
		List<BaseExercise> exerciseSelection = new List<BaseExercise> ();
		int timeLeft =  length * 60; //converted to seconds

		// select all exercises that align with the user prefs
		for (int n = 0; n < options.Length; n++) {
			if (alignment (options [n])) {
				exerciseSelection.Add (options [n]);
			}
		}

		// shuffle
		BaseExercise [] shuffledOptions = exerciseSelection.ToArray ();
		ShuffleArray (shuffledOptions);

		// only pick enough to make the correct time limit
		List<BaseExercise> actualExercises = new List<BaseExercise> ();
		int i = 0;
		while (timeLeft > 0) {
			actualExercises.Add (shuffledOptions [i]);
			int amount = shuffledOptions [i].length + shuffledOptions [i].restLength;
			timeLeft -= amount;
			totalTimeLength += amount + 2; // +2 cuz of timer descrepancy?

			// loop back around
			if (i >= shuffledOptions.Length - 1) {
				i = -1;
			}
			i++;
		}

		// convert to array
		return actualExercises.ToArray ();
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

		
		int n = warmupExercises.Length;

		if (n > 0) {
			str += "\t --Warmup--\n";
			for (int i = 0; i < n; i++) {
				str += "\t" + (i + 1) + ") " + warmupExercises [i].name + ". . . . . " + warmupExercises [i].length + " sec\n";
			}
			str += "\t --Main workout--\n";
		}

		n = exercises.Length;
		
		for (int i = 0; i < n; i++) {
			str += "\t" + (i + 1) + ") " + exercises [i].name + ". . . . . " + exercises [i].length + " sec\n";
		}
		return str;
	}
}