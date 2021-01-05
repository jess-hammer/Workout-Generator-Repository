using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImplementWorkout : MonoBehaviour
{
	/*public bool isRest = false;
	public int index = 0;

	public Text textbox;
	public Text nextTextbox;
	public Timer timer;

	// Start is called before the first frame update
	void Start()
    {
		textbox.text = "";
		nextTextbox.text = "";
	}

    // Update is called once per frame
    void Update()
    {
		runWorkout ();
		Generator.totalTimeLeft -= Time.deltaTime;
	}

	public void skipWorkout()
	{
		Generator.totalTimeLeft -= timer.timeLeft + 1;
		if (isRest == false && index < Generator.exercises.Length) {
			Generator.totalTimeLeft -= Generator.exercises [index].restLength + 1;
		}

		timer.setTimer (0, 0);
		isRest = false;
		index++;
	}

	public void runWorkout ()
	{
		BaseExercise [] exercises = Generator.exercises;

		if (exercises.Length == 0) {
			Debug.Log ("There are no exercises");
			return;
		}

		if (timer.isZero () && index < exercises.Length) {

			// display exercise
			if (isRest == false) {
				textbox.text = exercises [index].name;
				if (index < exercises.Length - 1) {
					nextTextbox.text = "Next up:  " + exercises [index + 1].name;
				} else {
					nextTextbox.text = "";
				}

				// reset timer
				timer.setTimer (exercises [index].length / 60,
					exercises [index].length % 60);
				isRest = true;
			}

			// time for a mini rest inbetween excercises
			else {
				textbox.text = "Rest...";

				// reset timer
				timer.setTimer (exercises [index].restLength / 60,
					exercises [index].restLength % 60);
				index++;
				isRest = false;
			}
		}
	}*/

}
