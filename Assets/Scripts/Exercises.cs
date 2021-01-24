using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Exercises {
	public static Exercise [] exercises;
	public static Exercise [] warmupExercises;
	public static Exercise [] cooldownExercises;
	public static bool isInitalised = false;


	// BODYFOCUS ARRAYS------------------------------------
	private static BodyFocus [] upper = { BodyFocus.Upper };
	private static BodyFocus [] middle = { BodyFocus.Middle };
	private static BodyFocus [] lower = { BodyFocus.Lower };
	private static BodyFocus [] upperMid = { BodyFocus.Upper, BodyFocus.Middle };
	private static BodyFocus [] upperLow = { BodyFocus.Upper, BodyFocus.Lower };
	private static BodyFocus [] middleLow = { BodyFocus.Middle, BodyFocus.Lower };
	private static BodyFocus [] allAreas = { BodyFocus.Upper, BodyFocus.Middle, BodyFocus.Lower };

	// TYPE ARRAYS-------------------------------------------
	private static Type [] strength = { Type.Strength };
	private static Type [] cardio = { Type.Cardio };
	private static Type [] hiit = { Type.HIIT };
	private static Type [] pilates = { Type.Pilates };
	private static Type [] stretching = { Type.Stretching };

	private static Type [] strengthCardio = { Type.Strength, Type.Cardio };
	private static Type [] strengthHIIT = { Type.Cardio, Type.HIIT };
	private static Type [] strengthPilates = { Type.Strength, Type.Pilates };
	private static Type [] cardioHIIT = { Type.Cardio, Type.HIIT };
	private static Type [] pilatesStretching = { Type.Pilates, Type.Stretching };
	private static Type [] strengthCardioHIIT = { Type.Strength, Type.Cardio, Type.HIIT };

	// EQUIPMENT---------------------------------------------
	private static Equipment [] noEquipment = { Equipment.NoEquipment };
	private static Equipment [] dumbbells = { Equipment.Dumbbells };
	private static Equipment [] generalUpper = { Equipment.Barbell, Equipment.Dumbbells, Equipment.Kettlebell };
	private static Equipment [] anyWeights = { Equipment.Barbell, Equipment.Dumbbells, Equipment.Kettlebell, Equipment.MedicineBall };
	private static Equipment [] sepUpper = { Equipment.Dumbbells, Equipment.Kettlebell };
	private static Equipment [] canBeSingle = { Equipment.Dumbbells, Equipment.Kettlebell, Equipment.MedicineBall };



	public static void generateAllExerciseList ()
	{
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
		//exercises = exs.ToArray ();
		//warmupExercises = warmupExs.ToArray ();
		isInitalised = true;
	}

	public static void Initialise ()
	{
		List<Exercise> exs = new List<Exercise> ();
		List<Exercise> warmupExs = new List<Exercise> ();
		List<Exercise> cooldownExs = new List<Exercise> ();

		initialiseUpper (exs);
		initialiseMiddle (exs);
		initialiseLower (exs);


		exercises = exs.ToArray();
		warmupExercises = warmupExs.ToArray ();
		cooldownExercises = cooldownExs.ToArray ();
	}

	private static void initialiseUpper (List<Exercise> exs)
	{
		List<ExercisePart> sequence = new List<ExercisePart> ();

		// UPPER---------------------------------------------------------------------------------------------
		sequence.Add (new ExercisePart ("Half Push-ups", 30, 30));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, upper, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Push-ups", 20, 20));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, upper, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Push-ups", 30, 20));
		exs.Add (new Exercise (sequence, Difficulty.Tough, upper, strength, noEquipment));
		sequence.Clear ();

		ExercisePart pushUpHIIT = new ExercisePart ("Push-ups", 20, 10);
		sequence.Add (pushUpHIIT);
		sequence.Add (pushUpHIIT);
		exs.Add (new Exercise (sequence, Difficulty.Tough, upper, strengthHIIT, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Push-ups", 40, 20));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, upper, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bicep curls", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, generalUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Tricep dips", 20, 20));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, upper, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Tricep dips", 40, 20));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, upper, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Tricep dips", 60, 10));
		exs.Add (new Exercise (sequence, Difficulty.Tough, upper, strength, noEquipment));
		sequence.Clear ();

		ExercisePart triDipsHIIT = new ExercisePart ("Tricep dips", 20, 10);
		sequence.Add (triDipsHIIT);
		sequence.Add (triDipsHIIT);
		exs.Add (new Exercise (sequence, Difficulty.Tough, upper, strengthHIIT, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Skull Crushers", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, canBeSingle));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Chest Press (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, generalUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Reverse fly", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Reverse fly (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, sepUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lateral raises", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lateral raises (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, sepUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Chest Fly", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Chest Fly (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, generalUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Shoulder Press", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Shoulder Press (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, generalUpper));
		sequence.Clear ();
	}

	private static void initialiseMiddle (List<Exercise> exs)
	{
		List<ExercisePart> sequence = new List<ExercisePart> ();

		// MIDDLE---------------------------------------------------------------------------------------------
		sequence.Add (new ExercisePart ("Crunches", 20, 10));
		exs.Add (new Exercise (sequence, Difficulty.Easy, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Crunches", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Crunches", 70, 10));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Sit-ups", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Sit-ups", 60, 10));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bicycle Crunches", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bicycle Crunches", 70, 10));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Half-plank", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Plank", 60, 10));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Plank Taps", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Tough, upperMid, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Hip Dips", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Plank", 120, 10));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, middle, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Oblique Crunches (Left)", 50, 10));
		sequence.Add (new ExercisePart ("Oblique Crunches (Right)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Oblique Crunches (Left)", 30, 10));
		sequence.Add (new ExercisePart ("Oblique Crunches (Right)", 30, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Half Oblique Crunches (Left)", 40, 10));
		sequence.Add (new ExercisePart ("Half Oblique Crunches (Right)", 40, 10));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jackknife Crunches", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middleLow, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jackknife Crunches", 60, 15));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, middleLow, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jackknife Crunches (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, allAreas, strength, canBeSingle));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lying-down Leg Raises", 40, 15));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middleLow, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lying-down Leg Raises", 60, 15));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middleLow, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Russian Twists (Weighted)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Tough, upperMid, strengthPilates, canBeSingle));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Russian Twists", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, upperMid, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Mountain Climbers", 30, 15));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, allAreas, strengthCardio, noEquipment));
		sequence.Clear ();

		ExercisePart mClimbers = new ExercisePart ("Mountain Climbers", 20, 10);
		sequence.Add (mClimbers);
		sequence.Add (mClimbers);
		exs.Add (new Exercise (sequence, Difficulty.Challenging, allAreas, strengthCardioHIIT, noEquipment));
		sequence.Clear ();
	}

	private static void initialiseLower (List<Exercise> exs)
	{
		List<ExercisePart> sequence = new List<ExercisePart> ();

		sequence.Add (new ExercisePart ("Squats", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Squats (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Sumo Squats", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Sumo Squats (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Ski Squats", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Ski Squats (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Lunges", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Lunges (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lunges (Left)", 50, 10));
		sequence.Add (new ExercisePart ("Lunges (Right)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Weighted Lunges (Left)", 45, 15));
		sequence.Add (new ExercisePart ("Weighted Lunges (Right)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Curtsy Lunges", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Curtsy Lunges (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Side Lunges", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Side Lunges (Weighted)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Side Lunges (Left)", 50, 10));
		sequence.Add (new ExercisePart ("Side Lunges (Right)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Weighted Side Lunges (Left)", 45, 15));
		sequence.Add (new ExercisePart ("Weighted Side Lunges (Right)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Deadlifts", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Side Leg Raises (Standing)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Easy, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Standing Side Leg Raises (Left)", 45, 15));
		sequence.Add (new ExercisePart ("Standing Side Leg Raises (Right)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Back Leg Raises (Standing)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Easy, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Standing Back Leg Raises (Left)", 45, 15));
		sequence.Add (new ExercisePart ("Standing Back Leg Raises (Right)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Front Leg Raises (Standing)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.Easy, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Standing Front Leg Raises (Left)", 45, 15));
		sequence.Add (new ExercisePart ("Standing Front Leg Raises (Right)", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Straight Leg Raises (Left)", 50, 10));
		sequence.Add (new ExercisePart ("Straight Leg Raises (Right)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bent Leg Pulses (Left)", 50, 10));
		sequence.Add (new ExercisePart ("Bent Leg Pulses (Right)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Fire Hydrant (Left)", 50, 10));
		sequence.Add (new ExercisePart ("Fire Hydrant  (Right)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Calf Raises", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Calf Raises (Weighted)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bridges", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bridges (Weighted)", 50, 10));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Lunges", 15, 15));
		exs.Add (new Exercise (sequence, Difficulty.Tough, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Lunges", 30, 15));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		ExercisePart jumpLunges = new ExercisePart ("Jumping Lunges", 20, 10);
		sequence.Add (jumpLunges);
		sequence.Add (jumpLunges);
		exs.Add (new Exercise (sequence, Difficulty.Challenging, lower, strengthCardioHIIT, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Squats", 15, 15));
		exs.Add (new Exercise (sequence, Difficulty.Tough, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Squats", 30, 15));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		ExercisePart jumpSquats = new ExercisePart ("Jumping Squats", 20, 10);
		sequence.Add (jumpSquats);
		sequence.Add (jumpSquats);
		exs.Add (new Exercise (sequence, Difficulty.Challenging, lower, strengthCardioHIIT, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Rocket Squats", 45, 15));
		exs.Add (new Exercise (sequence, Difficulty.Tough, lower, strengthCardio, noEquipment));
		sequence.Clear ();
	}
}


public class Exercise {
	public ExercisePart [] sequence;
	public int difficulty;
	public int totalSequenceDuration;

	public BodyFocus [] bodyFocus;
	public Type [] type;
	public Equipment [] equipment;

	public Exercise (List<ExercisePart> sequence, Difficulty difficulty, BodyFocus [] bodyFocus, Type [] type, Equipment [] equipment)
	{
		this.sequence = sequence.ToArray();
		this.difficulty = (int)difficulty;

		totalSequenceDuration = 0;
		for (int i = 0; i < sequence.Count; i++) {
			totalSequenceDuration += sequence [i].length + sequence [i].restlength;
		}

		this.bodyFocus = bodyFocus;
		this.type = type;
		this.equipment = equipment;
	}
}

public class ExercisePart {
	public string name;
	public int length;
	public int restlength;

	public ExercisePart (string name, int length, int restlength){
		this.name = name;
		this.length = length;
		this.restlength = restlength;
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

public enum Type {
	Cardio,
	Strength,
	HIIT,
	Pilates,
	Stretching
}

public enum Equipment {
	NoEquipment,
	Dumbbells,
	Barbell,
	ExerciseBand,
	Bench,
	Kettlebell,
	MedicineBall,
	Treadmill
}

public enum BodyFocus {
	Upper,
	Middle,
	Lower
}

public enum Difficulty {
	Easy,
	LowImpact,
	Moderate,
	Tough,
	Challenging,
	DependsOnWeight
}
