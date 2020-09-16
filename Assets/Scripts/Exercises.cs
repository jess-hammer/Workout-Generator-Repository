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
		bool [] focus = new bool [3];

		// UPPER
		focus [0] = true;
		focus [1] = false;
		focus [2] = false;
		exercises.Add (new BaseExercise ("Push-ups", 4, 20, 10, focus));
		exercises.Add (new BaseExercise ("Pull-ups", 5, 20, 10, focus));
		exercises.Add (new BaseExercise ("Bicep curls", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Tricep dips", 4, 20, 10, focus));
		exercises.Add (new BaseExercise ("Skull crushers", 5, 20, 10, focus));
		exercises.Add (new BaseExercise ("Chest press", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Reverse fly", 4, 20, 10, focus));
		exercises.Add (new BaseExercise ("Lateral raises", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Chest fly", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Shoulder press", 3, 20, 10, focus));


		// MIDDLE
		focus [0] = false;
		focus [1] = true;
		focus [2] = false;
		exercises.Add (new BaseExercise ("Crunches", 2, 20, 10, focus));
		exercises.Add (new BaseExercise ("Bicycle crunches", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Plank", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Mountain climbers", 5, 20, 10, focus));
		exercises.Add (new BaseExercise ("Oblique crunches", 2, 20, 10, focus));
		exercises.Add (new BaseExercise ("Jackknife crunches", 4, 20, 10, focus));
		exercises.Add (new BaseExercise ("Leg raises", 2, 20, 10, focus));
		exercises.Add (new BaseExercise ("Plank taps", 4, 20, 10, focus));
		exercises.Add (new BaseExercise ("Hip dips", 3, 20, 10, focus));


		// LOWER
		focus [0] = false;
		focus [1] = false;
		focus [2] = true;
		exercises.Add (new BaseExercise ("Squats", 2, 20, 10, focus));
		exercises.Add (new BaseExercise ("Sumo squats", 2, 20, 10, focus));
		exercises.Add (new BaseExercise ("Ski squats", 2, 20, 10, focus));
		exercises.Add (new BaseExercise ("Lunges", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Curtsey lunges", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Side lunges", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Deadlifts", 3, 20, 10, focus));
		exercises.Add (new BaseExercise ("Sidewards leg raises", 2, 20, 10, focus));
		exercises.Add (new BaseExercise ("Reverse leg raises", 2, 20, 10, focus));
		exercises.Add (new BaseExercise ("Calf raises", 2, 20, 10, focus));
		exercises.Add (new BaseExercise ("Bridges", 3, 20, 10, focus));

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

	public BaseExercise(string name, int difficulty, int length, int restLength, bool [] focus) {
		this.name = name;
		this.difficulty = difficulty;
		this.length = length;
		this.restLength = restLength;

		this.isUpper = focus [0];
		this.isMiddle = focus [1];
		this.isLower = focus [2];
	}
}