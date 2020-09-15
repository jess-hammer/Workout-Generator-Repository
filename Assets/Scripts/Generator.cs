using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Generator : MonoBehaviour
{
	public static int seed;
	public static UserPrefs userPrefs;
	public static List<BaseExercise> exerciseSelection;
	public static BaseExercise [] exercises;
	public static Exercises exerciseClass;
	
	
	// Start is called before the first frame update
	void Start() {
		exerciseClass = new Exercises ();
		exerciseSelection = new List<BaseExercise> ();
		exercises = new BaseExercise [0];
	}

    // Update is called once per frame
    void Update() {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			ImplementWorkout.index = 0;
			exercises = CreateWorkout ();
			if (exercises.Length > 0) {
				ImplementWorkout.isGenerated = true;
			}
			printExercises (exercises);
		}
	}

	// returns an array of excercises in random order
	public BaseExercise [] CreateWorkout ()
	{
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
		return exArray;
	}

	// returns true if exercise matches the user prefs
	public bool alignment(BaseExercise exercise)
	{
		return true;
	}

	void ShuffleArray<T> (T [] array)
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
	public void printExercises (BaseExercise [] array)
	{
		string str = "";
		for (int i = 0; i < array.Length; i++) {
			str += array [i].name + ", ";
		}
		Debug.Log (str);
	}
}