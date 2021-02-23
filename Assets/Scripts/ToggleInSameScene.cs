using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInSameScene : MonoBehaviour
{
	public GameObject [] page1;
	public GameObject [] page2;
	public GameObject [] page3;
	public GameObject [] page4;

	private GameObject [] [] objects;
	public UserPrefs userPrefs;
	public int curPos = 0;

	public void Start ()
	{
		objects = new GameObject [4] [];
		objects [0] = page1;
		objects [1] = page2;
		objects [2] = page3;
		objects [3] = page4;
	}

	public void Next()
	{
		if (userPrefs.isValid ()) {
			setArrayActive (objects[curPos], false);
			setArrayActive (objects[curPos + 1], true);
			curPos += 1;
		}
	}

	public void Back ()
	{
		//if (userPrefs.isValid ()) {
			setArrayActive (objects [curPos], false);
			setArrayActive (objects [curPos - 1], true);
			curPos -= 1;
		//}
	}

	
	private void setArrayActive(GameObject [] array, bool active)
	{
		for (int i = 0; i < array.Length; i++) {
			array [i].SetActive (active);
		}
	}
}
