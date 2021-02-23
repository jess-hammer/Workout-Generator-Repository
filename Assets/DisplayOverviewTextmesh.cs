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
	public TextMeshProUGUI focus;
	public TextMeshProUGUI equipment;
	public TextMeshProUGUI type;
	public TextMeshProUGUI workout;

	// Start is called before the first frame update
	void OnEnable ()
	{
		generator.CreateWorkout ();
		difficulty.text = "Difficulty: " + userPrefs.difficultyToString ();
		duration.text = "Duration: " + userPrefs.totalDuration + " min";
		focus.text = "Focus: " + userPrefs.focusAreaToString();
		equipment.text = "Equipment: " + userPrefs.ListToString<Equipment> (userPrefs.equipment);
		type.text = "Workout Type: " + userPrefs.ListToString<Type>(userPrefs.workoutType);
		workout.text = generator.toString ();
	}

	public void CopyToClipboard()
	{
		string str = "";
		str += difficulty.text + "\n";
		str += duration.text + "\n";
		str += focus.text + "\n";
		str += equipment.text + "\n";
		str += type.text + "\n";
		str += workout.text + "\n";
		ClipboardExtension.CopyToClipboard (str);
	}

	public void Refresh()
	{
		generator.CreateWorkout ();
		difficulty.text = "Difficulty: " + userPrefs.difficultyToString ();
		duration.text = "Duration: " + userPrefs.totalDuration + " min";
		focus.text = "Focus: " + userPrefs.focusAreaToString ();
		equipment.text = "Equipment: " + userPrefs.ListToString<Equipment> (userPrefs.equipment);
		type.text = "Workout Type: " + userPrefs.ListToString<Type> (userPrefs.workoutType);
		workout.text = generator.toString ();
	}
}
