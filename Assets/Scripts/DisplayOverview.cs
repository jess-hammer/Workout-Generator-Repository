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
		difficulty.text = "Difficulty: " + UserPrefs.difficulty;
		duration.text = "Duration: " + UserPrefs.duration  + " min";
		workout.text = Generator.toString ();
	}
}
