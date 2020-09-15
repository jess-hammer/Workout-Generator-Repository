using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPrefs : MonoBehaviour
{
	public static UserPref prefs;

    // Start is called before the first frame update
    void Start()
    {
		prefs = new UserPref ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class UserPref {
	public int durationMin = 15;
	public int difficulty = 3;

	public bool upperFocus = true;
	public bool coreFocus = true;
	public bool bottomFocus = true;
}