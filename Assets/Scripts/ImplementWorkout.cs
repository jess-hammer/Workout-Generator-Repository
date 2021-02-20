using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImplementWorkout : MonoBehaviour
{
	public bool isRest = false;
	private float totalTimeLeft;
	private float totalDuration;
	public TextMeshProUGUI textbox;
	public TextMeshProUGUI nextTextbox;
	public Timer timer;
	public Image exerciseIcon;
	private Animator anim;
	Queue<ExercisePart> exerciseQueue;
	Generator generator;
	ExercisePart currentEx;
	bool isFinished = false;

	// Start is called before the first frame update
	void Start()
    {
		generator = GameObject.FindWithTag ("System").GetComponent<Generator> ();
		textbox.text = "";
		nextTextbox.text = "";
		totalTimeLeft = generator.totalTimeLength;
		totalDuration = generator.totalTimeLength;
		exerciseQueue = convertToParts ();
		currentEx = exerciseQueue.Dequeue ();
		anim = exerciseIcon.GetComponent<Animator> ();
	}

	private Queue<ExercisePart> convertToParts()
	{
		Queue<ExercisePart> queue = new Queue<ExercisePart> ();
		convertSegmentToParts (generator.warmupExercises, queue);
		if (queue.Count > 0) {
			queue.Enqueue (new ExercisePart ("Time for the main workout!", 10, 0));
		}
		convertSegmentToParts (generator.exercises, queue);
		if (queue.Count > 0 && generator.cooldownExercises.Length > 0) {
			queue.Enqueue (new ExercisePart ("Great job, time to cool down", 10, 0));
		}
		convertSegmentToParts (generator.cooldownExercises, queue);

		queue.Enqueue (new ExercisePart ("Finish", 0, 0));
		Debug.Log ("converted");
		return queue;
	}

	void convertSegmentToParts (Exercise [] exs, Queue<ExercisePart> queue)
	{
		if (exs == null) {
			Debug.Log ("Null array??");
			return;
		}

		for (int i = 0; i < exs.Length; i++) {
			for (int j = 0; j < exs[i].sequence.Length; j++) {
				queue.Enqueue (exs [i].sequence [j]);
			}
		}
	}

	// Update is called once per frame
	void Update()
    {
		if (!isFinished) {
			runWorkout ();
			totalTimeLeft -= Time.deltaTime;
		}
	}

	public void skipWorkout()
	{
		if (exerciseQueue.Count <= 1) {
			executeFinish ();
			return;
		}


		totalTimeLeft -= timer.timeLeft + 1;

		isRest = false;
		updateCurrent ();
		playExercise ();

	}

	public void runWorkout ()
	{

		if (timer.isZero ()) {
			// check if finished
			if (exerciseQueue.Count == 0) {
				executeFinish ();
				return;
			}


			if (!isRest) {
				playExercise();
				isRest = true;
			} else {
				playRest ();
				isRest = false;
				updateCurrent ();
			}
		}
	}

	public void playExercise()
	{
		if (currentEx == null || currentEx.length == 0) {
			Debug.Log ("exited early");
			return;
		}

		textbox.text = currentEx.name;
		anim.Play (currentEx.clip);

		if (exerciseQueue.Count > 0) {
			nextTextbox.text = "Next up:  " + exerciseQueue.Peek ().name;
		} else {
			nextTextbox.text = "";
		}

		// reset timer
		timer.setTimer (currentEx.length / 60, currentEx.length % 60);
	}

	public void playRest ()
	{
		if (currentEx == null || currentEx.restlength == 0) {
			Debug.Log ("exited early");
			return;
		}

		textbox.text = "Rest";

		// reset timer
		timer.setTimer (currentEx.restlength / 60, currentEx.restlength % 60);
	}

	public void executeFinish()
	{
		isFinished = true;
		textbox.text = "You're all finished, well done!";
		nextTextbox.text = "";
		timer.hideTimer ();
		anim.StopPlayback ();
		exerciseIcon.sprite = null;

	}

	public void updateCurrent()
	{
		if (exerciseQueue.Count > 0) {
			currentEx = exerciseQueue.Dequeue ();
		}
	}

	public void goToNext()
	{
		if (exerciseQueue.Count == 0) {
			isFinished = true;
			textbox.text = "You're all finished, well done!";
			nextTextbox.text = "";
			return;
		}

		currentEx = exerciseQueue.Dequeue ();

		if (currentEx.length == 0 && currentEx.restlength == 0) {
			return;
		}

		// display exercise
		if (!isRest) {
			textbox.text = currentEx.name;
			if (exerciseQueue.Count > 0) {
				nextTextbox.text = "Next up:  " + exerciseQueue.Peek ().name;
			} else {
				nextTextbox.text = "";
			}

			// reset timer
			timer.setTimer (currentEx.length / 60, currentEx.length % 60);
			isRest = true;
		}

		// time for a rest inbetween excercises
		else {
			textbox.text = "Rest";

			// reset timer
			timer.setTimer (currentEx.restlength / 60, currentEx.restlength % 60);
			isRest = false;
		}
	}

}
