using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercises
{
	public static List<BaseExercise> exercises;

	public Exercises()
	{
		exercises = new List<BaseExercise> ();
		exercises.Add (new BaseExercise ("Push-ups", 4, 5, 3));
		exercises.Add (new BaseExercise ("Crunches", 2, 10, 3));
		exercises.Add (new BaseExercise ("Squats", 2, 6, 3));
		exercises.Add (new BaseExercise ("Lunges", 3, 3, 3));
		exercises.Add (new BaseExercise ("Deadlifts", 3, 10, 3));
		exercises.Add (new BaseExercise ("Leg lifts", 2, 3, 3));
		exercises.Add (new BaseExercise ("Calf raises", 2, 3, 3));
	}
}


[Serializable]
public class BaseExercise {
	public string name;
	public int difficulty;

	// type
	public bool isWithoutGear;
	public bool isCardio;
	public bool isStrengthTraining;
	public bool isStretch;

	// body focus (want to make more specific eventually) THESE DONT HAVE TO BE BOOLEAN
	public bool isUpper;
	public bool isMiddle;
	public bool isLower;

	// layout
	public int length;
	public int restLength;
	public int repeats;

	public BaseExercise(string name, int difficulty, int length, int restLength) {
		this.name = name;
		this.difficulty = difficulty;
		this.length = length;
		this.restLength = restLength;
	}
}