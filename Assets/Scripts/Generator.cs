using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	public int seed;
	public static UserPrefs userPrefs;
	public static List<BaseExcerciseClass> excerciseLineup;
	public BaseExcerciseClass [] shuffledLineup;
	private Excercises exClass;

	// Start is called before the first frame update
	void Start()
    {
		exClass = GetComponent<Excercises> ();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.Space)) {
			shuffledLineup = CreateWorkout ();
			printEx (shuffledLineup);
		}

	}

	public void printEx(BaseExcerciseClass [] array)
	{
		for (int i = 0; i < array.Length; i++) {
			Debug.Log (array[i].name);
		}
	}

	public BaseExcerciseClass [] CreateWorkout ()
	{
		seed = (int)UnityEngine.Random.Range (-10000, 10000);
		UnityEngine.Random.InitState (seed);

		foreach (BaseExcerciseClass ex in exClass.excercises) {
			if (alignment(ex)) {
				excerciseLineup.Add (ex);
			}
		}

		var exArray = excerciseLineup.ToArray ();
		ShuffleArray (exArray);

		return exArray;
	}

	public bool alignment(BaseExcerciseClass ex)
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
}

[Serializable]
public class UserPrefs {
	public int durationMin;
	public int difficulty;

	public bool upperFocus;
	public bool coreFocus;
	public bool bottomFocus;
}