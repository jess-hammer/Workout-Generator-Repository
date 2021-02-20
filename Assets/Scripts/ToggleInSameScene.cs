using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInSameScene : MonoBehaviour
{
	public GameObject [] customiserObjects;
	public GameObject [] customiser2Objects;
	public GameObject [] overviewObjects;
	public UserPrefs userPrefs;


    public void Page1To2()
	{
		if (userPrefs.isValid ()) {
			setArrayActive (customiser2Objects, true);
			setArrayActive (customiserObjects, false);
		}
	}

	public void Page2To1 ()
	{
		if (userPrefs.isValid ()) {
			setArrayActive (customiserObjects, true);
			setArrayActive (customiser2Objects, false);
		}
	}

	public void Page2To3 ()
	{
		if (userPrefs.isValid ()) {
			setArrayActive (overviewObjects, true);
			setArrayActive (customiser2Objects, false);
		}
	}

	public void Page3To2 ()
	{
		if (userPrefs.isValid ()) {
			setArrayActive (customiser2Objects, true);
			setArrayActive (overviewObjects, false);
		}
	}

	
	private void setArrayActive(GameObject [] array, bool active)
	{
		for (int i = 0; i < array.Length; i++) {
			array [i].SetActive (active);
		}
	}
}
