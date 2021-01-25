using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Generator : MonoBehaviour
{
	public Exercise [] warmupExercises;
	public Exercise [] cooldownExercises;
	public Exercise [] exercises;
	public float totalTimeLength = 0;
	private UserPrefs userPrefs;
	public int seed;
	

	public void Start ()
	{
		userPrefs = GetComponent<UserPrefs> ();
		seed = UnityEngine.Random.Range (-10000, 10000);
		UnityEngine.Random.InitState (seed);

		if (!Exercises.isInitalised) {
			//Exercises.generateAllExerciseList ();
			Exercises.Initialise ();
		}
	}

	// returns an array of excercises in random order
	public void CreateWorkout ()
	{
		//warmupExercises = GenerateFromList (Exercises.warmupExercises, userPrefs.warmup);
		warmupExercises = GenerateFromList (Exercises.warmupExercises, userPrefs.warmup, SegmentType.Warmup);
		exercises = GenerateFromList (Exercises.exercises, userPrefs.duration, SegmentType.Workout);
		cooldownExercises = new Exercise [0];
	}


	private Exercise [] GenerateFromList(Exercise [] options, int length, SegmentType segmentType)
	{
		// initalise variables
		List<Exercise> exerciseSelection = new List<Exercise> ();
		int timeLeft =  length * 60; //converted to seconds

		// shuffle

		ShuffleArray (options);

		// select all exercises that align with the user prefs
		if (segmentType == SegmentType.Warmup) {
			for (int n = 0; n < options.Length; n++) {
				if (warmupAlignment (options [n])) {
					exerciseSelection.Add (options [n]);
				}
			}
		} else {
			for (int n = 0; n < options.Length; n++) {
				if (alignment (options [n])) {
					exerciseSelection.Add (options [n]);
				}
			}
		}
		

		Exercise [] shuffledOptions = exerciseSelection.ToArray ();

		// only pick enough to make the correct time limit
		List<Exercise> actualExercises = new List<Exercise> ();
		int i = 0;
		while (timeLeft > 0) {
			actualExercises.Add (shuffledOptions [i]);
			int amount = shuffledOptions [i].totalSequenceDuration;
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
	public bool alignment(Exercise exercise)
	{
		float randNum = UnityEngine.Random.value;
		int diff1 = userPrefs.difficulty;
		int diff2 = exercise.difficulty;

		// check difficulty
		if (!(exercise.difficulty == 5 || diff1 == diff2 ||
			((diff2 == diff1 - 1 || diff2 == diff1 + 1) && randNum < 0.2))) {
			return false; // incorrect difficulty
		}

		// check body focus
		for (int i = 0; i < exercise.bodyFocus.Length; i++) {
			if (userPrefs.upperFocus && exercise.bodyFocus[i] == BodyFocus.Upper) {
				return true;
			}
			if (userPrefs.middleFocus && exercise.bodyFocus [i] == BodyFocus.Middle) {
				return true;
			}
			if (userPrefs.lowerFocus && exercise.bodyFocus [i] == BodyFocus.Lower) {
				return true;
			}
		}
		

		return false;
	}

	public bool warmupAlignment (Exercise exercise)
	{
		float randNum = UnityEngine.Random.value;
		int diff1 = userPrefs.difficulty;
		int diff2 = exercise.difficulty;

		// check difficulty
		if (!(exercise.difficulty == 5 || diff1 == diff2 || 
			(randNum < 0.6 && (diff2 == diff1 - 1 || diff2 == diff1 + 1) ))) {
			return false; // incorrect difficulty
		}

		// check body focus
		for (int i = 0; i < exercise.bodyFocus.Length; i++) {
			if (userPrefs.upperFocus && exercise.bodyFocus [i] == BodyFocus.Upper) {
				return true;
			}
			if (userPrefs.middleFocus && exercise.bodyFocus [i] == BodyFocus.Middle) {
				return true;
			}
			if (userPrefs.lowerFocus && exercise.bodyFocus [i] == BodyFocus.Lower) {
				return true;
			}
		}


		return false;
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

	

	public string toString ()
	{
		string str = "";

		
		str += arrayToString (warmupExercises, "Warmup");
		str += arrayToString (exercises, "Main Workout");
		str += arrayToString (cooldownExercises, "Cooldown");

		return str;
	}

	private string arrayToString(Exercise [] exs, string title)
	{
		string str = "";

		// null check
		if (exs == null) {
			str += "-- No " + title + " --\n";
			return str;
		}

		
		int count = 1;
		if (exs.Length > 0) {
			str += "-- " + title + " --\n";

			for (int i = 0; i < exs.Length; i++) {
				for (int j = 0; j < exs [i].sequence.Length; j++) {
					str += count + ") " + exs [i].sequence[j].name + ". . . . "
						+ exs [i].sequence [j].length + "s on + " + exs [i].sequence [j].restlength + "s off\n";
					count++;
				}
			}

		} else {
			str += "-- No " + title + " --\n";
		}
		return str;
	}

	public enum SegmentType {
		Warmup,
		Workout,
		Cooldown
	}
}