using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercises : MonoBehaviour
{
	public static List<BaseExercise> exercises;

	public Exercises()
	{
		exercises = new List<BaseExercise> ();
		exercises.Add (new BaseExercise("Push-ups", 4, 0, 30));
		exercises.Add (new BaseExercise ("Crunches", 2, 0, 50));
		exercises.Add (new BaseExercise ("Squats", 2, 0, 50));
		exercises.Add (new BaseExercise ("Lunges", 3, 0, 30));
		exercises.Add (new BaseExercise ("Deadlifts", 3, 0, 30));

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
	public int timerLengthMinutes;
	public int timerLengthSeconds;
	public int timerRestLength;
	public int timerRepeats;

	public BaseExercise(string name, int difficulty, int timerLengthMinutes, int timerLengthSeconds)
	{
		this.name = name;
		this.difficulty = difficulty;
		this.timerLengthMinutes = timerLengthMinutes;
		this.timerLengthSeconds = timerLengthSeconds;
	}
}