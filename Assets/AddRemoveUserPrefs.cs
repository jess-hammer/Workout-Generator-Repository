using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddRemoveUserPrefs : MonoBehaviour
{
	UserPrefs userPrefs;
	public string text;

    // Start is called before the first frame update
    void Start()
    {
		userPrefs = GameObject.FindGameObjectWithTag ("System").GetComponent<UserPrefs> ();
    }

    public void UpdateLists(Boolean isOn)
    {
        switch (text) {
		case "CARDIO":
			updateItemIn (Type.Cardio, isOn, userPrefs.workoutType);
			break;
		case "STRENGTH":
			updateItemIn (Type.Strength, isOn, userPrefs.workoutType);
			break;
		case "HIIT":
			updateItemIn (Type.HIIT, isOn, userPrefs.workoutType);
			break;
		case "PILATES":
			updateItemIn (Type.Pilates, isOn, userPrefs.workoutType);
			break;
		case "STRETCHING":
			updateItemIn (Type.Stretching, isOn, userPrefs.workoutType);
			break;
		case "NO EQUIPMENT":
			updateItemIn (Equipment.NoEquipment, isOn, userPrefs.equipment);
			break;
		case "DUMBBELLS":
			updateItemIn (Equipment.Dumbbells, isOn, userPrefs.equipment);
			break;
		case "BARBELL":
			updateItemIn (Equipment.Barbell, isOn, userPrefs.equipment);
			break;
		case "BENCH":
			updateItemIn (Equipment.Bench, isOn, userPrefs.equipment);
			break;
		case "RESISTANCE BAND":
			updateItemIn (Equipment.ExerciseBand, isOn, userPrefs.equipment);
			break;
		case "KETTLEBELL":
			updateItemIn (Equipment.Kettlebell, isOn, userPrefs.equipment);
			break;
		case "MEDICINEBALL":
			updateItemIn (Equipment.MedicineBall, isOn, userPrefs.equipment);
			break;
		case "TREADMILL":
			updateItemIn (Equipment.Treadmill, isOn, userPrefs.equipment);
			break;
		default:
			Debug.Log ("Failed to update " + text + "; case not found!");
			break;
		}
    }

	private void updateItemIn(Type type, bool isOn, List<Type> list)
	{
		if (isOn) {
			if (!list.Contains(type)) {
				list.Add (type);
				//Debug.Log ("Successfully added");
			} else {
				Debug.Log ("Tried to add " + text + " to list when it's already there");
			}
		} else {
			if (list.Contains (type)) {
				list.Remove (type);
			} else {
				Debug.Log ("Tried to remove " + text + " from list when it's already gone");
			}
		}
	}

	private void updateItemIn (Equipment type, bool isOn, List<Equipment> list)
	{
		if (isOn) {
			if (!list.Contains (type)) {
				list.Add (type);
				//Debug.Log ("Successfully added");
			} else {
				Debug.Log ("Tried to add " + text + " to list when it's already there");
			}
		} else {
			if (list.Contains (type)) {
				list.Remove (type);
			} else {
				Debug.Log ("Tried to remove " + text + " from list when it's already gone");
			}
		}
	}
}
