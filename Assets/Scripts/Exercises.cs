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
	private static Type [] stretchingCardio = { Type.Cardio, Type.Stretching };
	private static Type [] pilatesCardioStretching = { Type.Cardio, Type.Pilates, Type.Stretching };

	// EQUIPMENT---------------------------------------------
	private static Equipment [] noEquipment = { Equipment.NoEquipment };
	private static Equipment [] dumbbells = { Equipment.Dumbbells };
	private static Equipment [] generalUpper = { Equipment.Barbell, Equipment.Dumbbells, Equipment.Kettlebell };
	private static Equipment [] anyWeights = { Equipment.Barbell, Equipment.Dumbbells, Equipment.Kettlebell, Equipment.MedicineBall };
	private static Equipment [] sepUpper = { Equipment.Dumbbells, Equipment.Kettlebell };
	private static Equipment [] canBeSingle = { Equipment.Dumbbells, Equipment.Kettlebell, Equipment.MedicineBall };


	public static void Initialise ()
	{
		List<Exercise> exs = new List<Exercise> ();
		List<Exercise> warmupExs = new List<Exercise> ();
		List<Exercise> cooldownExs = new List<Exercise> ();

		initialiseUpper (exs);
		initialiseMiddle (exs);
		initialiseLower (exs);

		initialiseWarmupsAndCooldowns (warmupExs, cooldownExs);
		initialiseWarmups (warmupExs);
		initialiseCooldowns (cooldownExs);

		exercises = exs.ToArray();
		warmupExercises = warmupExs.ToArray ();
		cooldownExercises = cooldownExs.ToArray ();
	}

	// UPPER---------------------------------------------------------------------------------------------
	private static void initialiseUpper (List<Exercise> exs)
	{
		List<ExercisePart> sequence = new List<ExercisePart> ();

		sequence.Add (new ExercisePart ("Half Push-ups", 30, 30, "Half Pushups"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, upper, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Push-ups", 20, 20, "Pushups"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, upper, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Push-ups", 30, 20, "Pushups"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, upper, strength, noEquipment));
		sequence.Clear ();

		ExercisePart pushUpHIIT = new ExercisePart ("Push-ups", 20, 10, "Pushups");
		sequence.Add (pushUpHIIT);
		sequence.Add (pushUpHIIT);
		exs.Add (new Exercise (sequence, Difficulty.Tough, upper, strengthHIIT, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Push-ups", 40, 20, "Pushups"));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, upper, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bicep Curls", 50, 10, "Bicep Curls"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, generalUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Tricep Dips", 20, 20, "Tricep Dips"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, upper, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Tricep Dips", 40, 20, "Tricep Dips"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, upper, strength, noEquipment));
		sequence.Clear ();

		ExercisePart triDipsHIIT = new ExercisePart ("Tricep Dips HIIT", 20, 10, "Tricep Dips");
		sequence.Add (triDipsHIIT);
		sequence.Add (triDipsHIIT);
		exs.Add (new Exercise (sequence, Difficulty.Tough, upper, strengthHIIT, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Skull Crushers", 50, 10, "Skull Crushers"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, canBeSingle));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Overhead Tricep Extensions", 50, 10, "Tricep Extensions"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, canBeSingle));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Chest Press", 45, 15, "Chest Press"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, generalUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lateral Raises (Without Weights)", 50, 10, "Lateral Raises"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lateral Raises", 45, 15, "Lateral Raises (Weighted)"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, sepUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Reverse Fly (Without Weights)", 50, 10, "Reverse Fly"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Reverse Fly", 45, 15, "Reverse Fly"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, sepUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Chest Fly", 45, 15, "Chest Fly"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, generalUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Shoulder Press (Without Weights)", 50, 10, "Shoulder Press"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Shoulder Press", 45, 15, "Shoulder Press"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, generalUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Front Raises", 45, 15, "Front Raises"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, generalUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bent Rows", 45, 15, "Bent Rows"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, sepUpper));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Tricep Kickbacks", 45, 15, "Tricep Kickbacks"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, upper, strength, sepUpper));
		sequence.Clear ();
	}

	// MIDDLE---------------------------------------------------------------------------------------------
	private static void initialiseMiddle (List<Exercise> exs)
	{
		List<ExercisePart> sequence = new List<ExercisePart> ();

		sequence.Add (new ExercisePart ("Crunches", 20, 10, "Crunches"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, middle, strengthPilates, noEquipment));
		sequence.Clear ();
		
		sequence.Add (new ExercisePart ("Crunches", 50, 10, "Crunches")); 
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Crunches", 70, 10, "Crunches"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Sit-ups", 45, 15, "Sit-ups"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Sit-ups", 60, 10, "Sit-ups"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bicycle Crunches", 50, 10, "Bicycle Crunches"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bicycle Crunches", 70, 10, "Bicycle Crunches"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Half Plank", 50, 10, "Half Plank"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Plank", 60, 10, "Plank"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Reverse Plank", 60, 10, "Reverse Plank"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Plank", 120, 10, "Plank"));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, middle, strength, noEquipment));
		sequence.Clear ();

		//sequence.Add (new ExercisePart ("Plank Taps", 50, 10)); //not drawn
		//exs.Add (new Exercise (sequence, Difficulty.Tough, upperMid, strength, noEquipment));
		//sequence.Clear ();

		sequence.Add (new ExercisePart ("Hip Dips", 50, 10, "Hip Dips"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Hip Dips", 30, 10, "Hip Dips"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, middle, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Oblique Crunches (Left)", 50, 10, "Oblique Crunches"));
		sequence.Add (new ExercisePart ("Oblique Crunches (Right)", 50, 10, "Oblique Crunches"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Side Hip Raises (Left)", 50, 10, "Side Hip Raises"));
		sequence.Add (new ExercisePart ("Side Hip Raises (Right)", 50, 10, "Side Hip Raises"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Half Side Hip Raises (Left)", 50, 10, "Half Side Hip Raises"));
		sequence.Add (new ExercisePart ("Half Side Hip Raises (Right)", 50, 10, "Half Side Hip Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Weighted Side Hip Raises (Left)", 40, 10, "Weighted Side Hip Raises"));
		sequence.Add (new ExercisePart ("Weighted Side Hip Raises (Right)", 40, 10, "Weighted Side Hip Raises"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, canBeSingle));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Back Bows", 45, 15, "Back Bows"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middle, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Back Bows (Weighted)", 45, 15, "Weighted Back Bows"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middle, strengthPilates, canBeSingle));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jackknife Crunches", 45, 15, "Jacknife Crunches"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middleLow, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jackknife Crunches (Weighted)", 45, 15, "Jacknife Crunches"));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, allAreas, strength, canBeSingle));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lying-down Leg Raises", 40, 15, "Lying Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, middleLow, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lying-down Leg Raises", 60, 15, "Lying Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, middleLow, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Russian Twists (Weighted)", 50, 10, "Russian Twists"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, upperMid, strengthPilates, canBeSingle));
		sequence.Clear ();
		 
		sequence.Add (new ExercisePart ("Russian Twists", 45, 15, "Russian Twists"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, upperMid, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Mountain Climbers", 30, 15, "Mountain Climbers"));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, allAreas, strengthCardio, noEquipment));
		sequence.Clear ();

		ExercisePart mClimbers = new ExercisePart ("Mountain Climbers", 20, 10, "Mountain Climbers");
		sequence.Add (mClimbers);
		sequence.Add (mClimbers);
		exs.Add (new Exercise (sequence, Difficulty.Challenging, allAreas, strengthCardioHIIT, noEquipment));
		sequence.Clear ();
	}

	private static void initialiseLower (List<Exercise> exs)
	{
		List<ExercisePart> sequence = new List<ExercisePart> ();

		sequence.Add (new ExercisePart ("Squats", 50, 10, "Squats"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Squats (Weighted)", 45, 15, "Squats"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Sumo Squats", 50, 10, "Sumo Squats"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Sumo Squats (Weighted)", 45, 15, "Sumo Squats"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Ski Squats", 50, 10, "Ski Squats"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Ski Squats (Weighted)", 45, 15, "Ski Squats"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Lunges", 45, 15, "Alternating Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Lunges (Weighted)", 45, 15, "Alternating Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Lunges (Left)", 50, 10, "Lunges"));
		sequence.Add (new ExercisePart ("Lunges (Right)", 50, 10, "Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Weighted Lunges (Left)", 45, 15, "Lunges"));
		sequence.Add (new ExercisePart ("Weighted Lunges (Right)", 45, 15, "Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Reverse Lunges", 45, 15, "Alternating Reverse Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Reverse Lunges (Weighted)", 45, 15, "Alternating Reverse Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Reverse Lunges (Left)", 50, 10, "Reverse Lunges"));
		sequence.Add (new ExercisePart ("Reverse Lunges (Right)", 50, 10, "Reverse Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Weighted Reverse Lunges (Left)", 45, 15, "Reverse Lunges"));
		sequence.Add (new ExercisePart ("Weighted Reverse Lunges (Right)", 45, 15, "Reverse Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Curtsy Lunges", 50, 10, "Alternating Curtsy Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Curtsy Lunges (Weighted)", 45, 15, "Alternating Curtsy Lunges (Weighted)"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Curtsy Lunges (Left)", 50, 10, "Curtsy Lunges"));
		sequence.Add (new ExercisePart ("Curtsy Lunges (Right)", 50, 10, "Curtsy Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Weighted Curtsy Lunges (Left)", 45, 15, "Curtsy Lunges (Weighted)"));
		sequence.Add (new ExercisePart ("Weighted Curtsy Lunges (Right)", 45, 15, "Curtsy Lunges (Weighted)"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Side Lunges", 50, 10, "Side Lunges")); //currently not alternating
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Alternating Side Lunges (Weighted)", 45, 15, "Side Lunges")); //currently not alternating
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Side Lunges (Left)", 50, 10, "Side Lunges"));
		sequence.Add (new ExercisePart ("Side Lunges (Right)", 50, 10, "Side Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Weighted Side Lunges (Left)", 45, 15, "Side Lunges"));
		sequence.Add (new ExercisePart ("Weighted Side Lunges (Right)", 45, 15, "Side Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Deadlifts", 50, 10, "Deadlifts"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Standing Side Leg Raises (Left)", 45, 15, "Standing Side Leg Raises"));
		sequence.Add (new ExercisePart ("Standing Side Leg Raises (Right)", 45, 15, "Standing Side Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Standing Back Leg Raises (Left)", 45, 15, "Back Leg Raises"));
		sequence.Add (new ExercisePart ("Standing Back Leg Raises (Right)", 45, 15, "Back Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Standing Front Leg Raises (Left)", 45, 15, "Front Leg Raises"));
		sequence.Add (new ExercisePart ("Standing Front Leg Raises (Right)", 45, 15, "Front Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Straight Leg Raises (Left)", 50, 10, "Straight Leg Raises"));
		sequence.Add (new ExercisePart ("Straight Leg Raises (Right)", 50, 10, "Straight Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Straight Leg Pulses (Left)", 50, 10, "Straight Leg Pulses"));
		sequence.Add (new ExercisePart ("Straight Leg Pulses (Right)", 50, 10, "Straight Leg Pulses"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bent Leg Raises (Left)", 50, 10, "Bent Leg Raises"));
		sequence.Add (new ExercisePart ("Bent Leg Raises (Right)", 50, 10, "Bent Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bent Leg Pulses (Left)", 50, 10, "Bent Leg Pulses"));
		sequence.Add (new ExercisePart ("Bent Leg Pulses (Right)", 50, 10, "Bent Leg Pulses"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Fire Hydrant (Left)", 50, 10, "Fire Hydrant"));
		sequence.Add (new ExercisePart ("Fire Hydrant  (Right)", 50, 10, "Fire Hydrant"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Side Leg Raises (Left)", 50, 10, "Side Leg Raises"));
		sequence.Add (new ExercisePart ("Side Leg Raises (Right)", 50, 10, "Side Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Inner Leg Raises (Left)", 50, 10, "Inner Leg Raises"));
		sequence.Add (new ExercisePart ("Inner Leg Raises (Right)", 50, 10, "Inner Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Calf Raises", 50, 10, "Calf Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Calf Raises (Weighted)", 50, 10, "Calf Raises"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bridges", 50, 10, "Bridges"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strength, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Bridges (Weighted)", 50, 10, "Bridges (Weighted)"));
		exs.Add (new Exercise (sequence, Difficulty.DependsOnWeight, lower, strength, anyWeights));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Lunges", 15, 15, "Jumping Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Lunges", 30, 15, "Jumping Lunges"));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		ExercisePart jumpLunges = new ExercisePart ("Jumping Lunges", 20, 10, "Jumping Lunges");
		sequence.Add (jumpLunges);
		sequence.Add (jumpLunges);
		exs.Add (new Exercise (sequence, Difficulty.Challenging, lower, strengthCardioHIIT, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Squats", 15, 15, "Jumping Squats"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Squats", 30, 15, "Jumping Squats"));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		ExercisePart jumpSquats = new ExercisePart ("Jumping Squats", 20, 10, "Jumping Squats");
		sequence.Add (jumpSquats);
		sequence.Add (jumpSquats);
		exs.Add (new Exercise (sequence, Difficulty.Challenging, lower, strengthCardioHIIT, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Rocket Squats", 45, 15, "Rocket Squats"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, lower, strengthCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Tuck Jumps", 30, 15, "Tuck Jumps"));
		exs.Add (new Exercise (sequence, Difficulty.Challenging, allAreas, cardio, noEquipment));
		sequence.Clear ();

		ExercisePart tuckJumps = new ExercisePart ("Tuck Jumps HIIT", 20, 10, "Tuck Jumps");
		sequence.Add (tuckJumps);
		exs.Add (new Exercise (sequence, Difficulty.Challenging, allAreas, cardioHIIT, noEquipment));
		sequence.Clear ();
	}

	private static void initialiseWarmups (List<Exercise> exs)
	{
		List<ExercisePart> sequence = new List<ExercisePart> ();

		sequence.Add (new ExercisePart ("Standing Side Leg Raises (Left)", 25, 5, "Standing Side Leg Raises"));
		sequence.Add (new ExercisePart ("Standing Side Leg Raises (Right)", 25, 5, "Standing Side Leg Raises"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, strengthPilates, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Torso Twists", 50, 10, "Torso Twists"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, middle, stretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Wide Hip Circles (Clockwise)", 20, 0, "Wide Hip Circles"));
		sequence.Add (new ExercisePart ("Wide Hip Circles (Anti-clockwise)", 20, 10, "Wide Hip Circles"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, middle, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Leg Swings (Right)", 45, 5, "Leg Swings"));
		sequence.Add (new ExercisePart ("Leg Swings (Left)", 45, 10, "Leg Swings"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, stretchingCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Front Kicks (Right)", 45, 10, "Front Kicks"));
		sequence.Add (new ExercisePart ("Front Kicks (Left)", 45, 10, "Front Kicks"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, lower, stretchingCardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jog In Place", 30, 10, "Jog In Place"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, allAreas, cardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jog In Place", 50, 10, "Jog In Place"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, allAreas, cardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Jacks", 50, 10, "Jumping Jacks"));
		exs.Add (new Exercise (sequence, Difficulty.Tough, allAreas, cardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Jumping Jacks", 30, 10, "Jumping Jacks"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, allAreas, cardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("High Knee Marches", 40, 10, "High Knee Marches"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, allAreas, cardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Cross Toe Touches", 40, 10, "Cross Toe Touches"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, upperMid, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Up & Outs", 50, 10, "Up And Outs"));
		exs.Add (new Exercise (sequence, Difficulty.Moderate, allAreas, cardio, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Rocking Arm Swings", 45, 10, "Rocking Arm Swings"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, allAreas, stretchingCardio, noEquipment));
		sequence.Clear ();
	}

	private static void initialiseWarmupsAndCooldowns (List<Exercise> exs, List<Exercise> cooldownExs)
	{
		List<ExercisePart> sequence = new List<ExercisePart> ();

		sequence.Add (new ExercisePart ("Sideways Reaches (Right)", 30, 5, "Sideways Reaches"));
		sequence.Add (new ExercisePart ("Sideways Reaches (Left)", 30, 5, "Sideways Reaches"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, upperMid, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Kneeling Stretch (Right)", 30, 5)); //not drawn
		sequence.Add (new ExercisePart ("Kneeling Stretch (Left)", 30, 5));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, stretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Toe Reach Stretch", 20, 5, "Toe Reach Stretch"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, allAreas, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Quad Stretch (Right)", 30, 5)); //not drawn
		sequence.Add (new ExercisePart ("Quad Stretch (Left)", 30, 5));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, lower, stretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Big Arm Circles", 20, 5)); //not drawn
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Wrist circles", 20, 5)); //not drawn
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, stretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Neck Rotations", 20, 5)); //not drawn
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, stretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Shoulder Stretch (Right)", 15, 5, "Arm Stretch"));
		sequence.Add (new ExercisePart ("Shoulder Stretch (Left)", 15, 5, "Arm Stretch"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Overhead Tricep Stretch (Right)", 15, 5, "Overhead Tricep Stretch"));
		sequence.Add (new ExercisePart ("Overhead Tricep Stretch (Left)", 15, 5, "Overhead Tricep Stretch"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, pilatesStretching, noEquipment));
		sequence.Clear ();

		foreach (Exercise ex in exs) {
			cooldownExs.Add (ex);
		}
	}

	private static void initialiseCooldowns (List<Exercise> exs)
	{
		List<ExercisePart> sequence = new List<ExercisePart> ();

		sequence.Add (new ExercisePart ("Glute Stretch (Left)", 20, 5, "Glute Stretch"));
		sequence.Add (new ExercisePart ("Glute Stretch (Right)", 20, 5, "Glute Stretch"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, lower, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Head To Knee Stretch (Right)", 20, 5, "Head To Knee Stretch"));
		sequence.Add (new ExercisePart ("Head To Knee Stretch (Left)", 20, 5, "Head To Knee Stretch"));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, allAreas, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Reclining Twist (Left)", 30, 5)); // not drawn
		sequence.Add (new ExercisePart ("Reclining Twist (Right)", 30, 5));
		exs.Add (new Exercise (sequence, Difficulty.Easy, lower, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Butterfly Stretch", 25, 5, "Butterfly Stretch"));
		exs.Add (new Exercise (sequence, Difficulty.Easy, lower, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Calf Stretch", 25, 5)); // not drawn
		exs.Add (new Exercise (sequence, Difficulty.Easy, lower, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Overhead Stretch", 25, 5)); // not drawn
		exs.Add (new Exercise (sequence, Difficulty.Easy, upper, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Chest Stretch", 25, 5)); // not drawn
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, upper, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Childs Pose", 30, 5)); // not drawn
		sequence.Add (new ExercisePart ("Cobra Pose", 20, 5)); // not drawn
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, allAreas, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Sitting Toe Reach (Left)", 20, 5)); //not drawn
		sequence.Add (new ExercisePart ("Sitting Toe Reach (Right)", 20, 5));
		exs.Add (new Exercise (sequence, Difficulty.LowImpact, middleLow, pilatesStretching, noEquipment));
		sequence.Clear ();

		sequence.Add (new ExercisePart ("Knee Hug (Left)", 20, 5)); //not drawn
		sequence.Add (new ExercisePart ("Knee Hug (Right)", 20, 5));
		exs.Add (new Exercise (sequence, Difficulty.Easy, lower, pilatesStretching, noEquipment));
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
	public string clip = "Empty";

	public ExercisePart (string name, int length, int restlength){
		this.name = name;
		this.length = length;
		this.restlength = restlength;
	}

	public ExercisePart (string name, int length, int restlength, string clip)
	{
		this.name = name;
		this.length = length;
		this.restlength = restlength;
		this.clip = clip;
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
