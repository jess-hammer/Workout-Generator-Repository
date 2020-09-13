using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Attach me to the textbox you want to display the timer!
public class Timer : MonoBehaviour
{
	private static float timeLeft = 5; // in seconds
	public static Text textBox; 

	public void setTimer (int minutes,  int seconds) {
		timeLeft = (minutes * 60) + seconds;
	}

	private void Start () {
		textBox = this.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update() {
		textBox.text = ((int)timeLeft / 60) + ":" + ((int)timeLeft % 60);

		if ((int)timeLeft > 0) {
			timeLeft -= Time.deltaTime;
		} 
		
    }
}
