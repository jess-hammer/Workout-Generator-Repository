using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayOverview : MonoBehaviour
{
	public Text duration;
	public Text difficulty;
	public Text workout;

	// Start is called before the first frame update
	void Start()
    {
		Generator.CreateWorkout ();
		duration.text = "Duration: " + UserPrefs.durationMin + " min";
		difficulty.text = "Difficulty: " + UserPrefs.difficulty;
		workout.text = Generator.toString ();
	}
}
