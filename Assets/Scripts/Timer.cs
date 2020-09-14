using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Attach me to the textbox you want to display the timer!
public class Timer : MonoBehaviour
{
	private static float timeLeft = 0; // in seconds
	public static Text textBox;
	private int prevMin;
	private int prevSec;

	public void setTimer (int minutes,  int seconds) {
		timeLeft = (minutes * 60) + seconds + 0.99f;
	}

	private void Start () {
		textBox = this.GetComponent<Text> ();
		prevMin = -1;
		prevSec = -1;
	}

	// Update is called once per frame
	void Update() {
		int curMin = (int)timeLeft / 60;
		int curSec = (int)timeLeft % 60;

		if (curSec != prevSec) {
			textBox.text = curMin + ":" + curSec.ToString ("00");
		}

		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
		} 
    }

	public bool isZero()
	{
		return timeLeft <= 0;
	}
}
