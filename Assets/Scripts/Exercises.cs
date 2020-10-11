using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercises
{
	public static int seed;
	public static BaseExercise [] exercises;
	public static BaseExercise [] warmupExercises;
	public static BaseExercise [] cooldownExercises;

	public Exercises()
	{
		seed = UnityEngine.Random.Range (-10000,10000);
		UnityEngine.Random.InitState (seed);

		List<BaseExercise> exs = new List<BaseExercise> ();
		List<BaseExercise> warmupExs = new List<BaseExercise> ();
		List<BaseExercise> cooldownExs = new List<BaseExercise> ();
		bool [] focus = new bool [3];

		// UPPER -----------------------------------------------------
		focus [0] = true;
		focus [1] = false;
		focus [2] = false;
		exs.Add (new BaseExercise ("Push-ups", 4, 50, 10, focus));
		exs.Add (new BaseExercise ("Pull-ups", 5, 50, 10, focus));
		exs.Add (new BaseExercise ("Bicep curls", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Tricep dips", 4, 50, 10, focus));
		exs.Add (new BaseExercise ("Skull crushers", 5, 50, 10, focus));
		exs.Add (new BaseExercise ("Chest press", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Reverse fly", 4, 50, 10, focus));
		exs.Add (new BaseExercise ("Lateral raises", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Chest fly", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Shoulder press", 3, 50, 10, focus));

		warmupExs.Add (new BaseExercise ("Big arm circles", 1, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Arm stretch", 1, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Flex towards sky", 1, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Push pulls", 1, 20, 10, focus));

		// MIDDLE ------------------------------------------------------------
		focus [0] = false;
		focus [1] = true;
		focus [2] = false;
		exs.Add (new BaseExercise ("Crunches", 2, 50, 10, focus));
		exs.Add (new BaseExercise ("Bicycle crunches", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Plank", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Mountain climbers", 5, 50, 10, focus));
		exs.Add (new BaseExercise ("Oblique crunches", 2, 50, 10, focus));
		exs.Add (new BaseExercise ("Jackknife crunches", 4, 50, 10, focus));
		exs.Add (new BaseExercise ("Leg raises", 2, 50, 10, focus));
		exs.Add (new BaseExercise ("Plank taps", 4, 50, 10, focus));
		exs.Add (new BaseExercise ("Hip dips", 3, 50, 10, focus));

		warmupExs.Add (new BaseExercise ("Standing torso twists", 1, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Sideways reach", 1, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Wide hip circles", 1, 50, 10, focus));


		// LOWER -------------------------------------------------------------
		focus [0] = false;
		focus [1] = false;
		focus [2] = true;
		exs.Add (new BaseExercise ("Squats", 2, 50, 10, focus));
		exs.Add (new BaseExercise ("Sumo squats", 2, 50, 10, focus));
		exs.Add (new BaseExercise ("Ski squats", 2, 50, 10, focus));
		exs.Add (new BaseExercise ("Lunges", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Curtsey lunges", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Side lunges", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Deadlifts", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Sidewards leg raises", 2, 50, 10, focus));
		exs.Add (new BaseExercise ("Reverse leg raises", 2, 50, 10, focus));
		exs.Add (new BaseExercise ("Calf raises", 2, 50, 10, focus));
		exs.Add (new BaseExercise ("Bridges", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Jumping lunges", 5, 20, 10, focus));
		exs.Add (new BaseExercise ("Jumping squats", 5, 20, 10, focus));
		exs.Add (new BaseExercise ("Rocket squats", 4, 20, 10, focus));

		warmupExs.Add (new BaseExercise ("Leg swings", 1, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Slow rocking butt kickers", 1, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Front kicks", 2, 50, 10, focus));

		// FULL BODY ---------------------------------------------------------
		focus [0] = true;
		focus [1] = true;
		focus [2] = true;
		exs.Add (new BaseExercise ("Jumping jacks", 3, 50, 10, focus));
		exs.Add (new BaseExercise ("Star jumps", 5, 20, 10, focus));
		exs.Add (new BaseExercise ("High knees", 5, 20, 10, focus));

		warmupExs.Add (new BaseExercise ("Jog in place", 2, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("High knee marches", 1, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Cross toe touches", 1, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Up & outs", 2, 50, 10, focus));
		warmupExs.Add (new BaseExercise ("Boxer shuffle", 1, 50, 10, focus));

		// shuffle it
		exercises = exs.ToArray ();
		Generator.ShuffleArray (exercises);
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