using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayOverview : MonoBehaviour
{
	public Generator generator;
	public UserPrefs userPrefs;
	public Text duration;
	public Text difficulty;
	public Text workout;

	// Start is called before the first frame update
	void OnEnable()
    {
		generator.CreateWorkout ();
		difficulty.text = "Difficulty: " + userPrefs.difficulty;
		duration.text = "Duration: " + userPrefs.duration  + " min";
		workout.text = generator.toString ();
	}
}
