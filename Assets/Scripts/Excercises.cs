using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excercises : MonoBehaviour
{
	
	public List<BaseExcerciseClass> excercises;
}


[Serializable]
public class BaseExcerciseClass {
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
}