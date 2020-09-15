using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImplementWorkout : MonoBehaviour
{
	public static bool isGenerated = false;
	public bool isRest = false;
	public static int index = 0;

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
	}

	public void runWorkout ()
	{
		if (timer.isZero () && index != Generator.exercises.Length) {
			if (isRest == false) {
				textbox.text = Generator.exercises [index].name;
				if (index < Generator.exercises.Length - 1) {
					nextTextbox.text = "Next up:  " + Generator.exercises [index + 1].name;
				} else {
					nextTextbox.text = "";
				}

				timer.setTimer (Generator.exercises [index].length / 60,
					Generator.exercises [index].length % 60);
				isRest = true;
			}

			// time for a mini rest inbetween excercises
			else {
				textbox.text = "Rest...";

				timer.setTimer (Generator.exercises [index].restLength / 60,
					Generator.exercises [index].restLength % 60);

				index++;
				isRest = false;
			}
		}
	}
}
