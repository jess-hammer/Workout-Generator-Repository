using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayOverviewTextmesh : MonoBehaviour
{
	public Generator generator;
	public UserPrefs userPrefs;
	public TextMeshProUGUI duration;
	public TextMeshProUGUI difficulty;
	public TextMeshProUGUI workout;

	// Start is called before the first frame update
	void OnEnable ()
	{
		generator.CreateWorkout ();
		difficulty.text = "Difficulty: " + userPrefs.difficultyToString ();
		duration.text = "Duration: " + userPrefs.totalDuration + " min";
		workout.text = generator.toString ();
	}
}
