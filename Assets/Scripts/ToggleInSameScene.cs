using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInSameScene : MonoBehaviour
{
	public GameObject [] customiserObjects;
	public GameObject [] overviewObjects;
	public UserPrefs userPrefs;


    public void CustomiserToOverview()
	{
		if (userPrefs.isValid ()) {
			setArrayActive (overviewObjects, true);
			setArrayActive (customiserObjects, false);
		}
	}

	public void OverviewToCustomiser ()
	{
		setArrayActive (customiserObjects, true);
		setArrayActive (overviewObjects, false);
	}

	private void setArrayActive(GameObject [] array, bool active)
	{
		for (int i = 0; i < array.Length; i++) {
			array [i].SetActive (active);
		}
	}
}
