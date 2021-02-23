using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
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
	public ProgressBar progressBar;
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
			queue.Enqueue (new ExercisePart ("Time for the main workout!", 10, 0, "Water Break"));
		}
		convertSegmentToParts (generator.exercises, queue);
		if (queue.Count > 0 && generator.cooldownExercises.Length > 0) {
			queue.Enqueue (new ExercisePart ("Great job, time to cool down", 10, 0, "Water Break"));
		}
		convertSegmentToParts (generator.cooldownExercises, queue);

		queue.Enqueue (new ExercisePart ("Finish", 0, 0, "Finish"));
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

		isRest = true;
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
				isRest = true;
				playExercise ();
				
			} else {
				isRest = false;
				playRest ();
				
				updateCurrent ();
			}
		}
	}

	public void playExercise()
	{
		//Debug.Log ("Playing excercise. Is rest = " + isRest);
		if (currentEx == null || currentEx.length <= 0.01) {
			Debug.Log ("exited excercise early");
			timer.setTimer (0, 0);
			return;
		}

		textbox.text = currentEx.name;
		exerciseIcon.enabled = true;
		anim.Play (currentEx.clip);

		if (exerciseQueue.Count > 0) {
			nextTextbox.text = "Next up:  " + exerciseQueue.Peek ().name;
		} else {
			nextTextbox.text = "";
		}

		// reset timer
		timer.setTimer (currentEx.length / 60, currentEx.length % 60);
		resetProgressBar (currentEx.length);
	}

	public void playRest ()
	{
		//Debug.Log ("Playing rest. Is rest = " + isRest);
		if (currentEx == null || currentEx.restlength <= 0.01) {
			Debug.Log ("exited rest early");
			timer.setTimer (0, 0);
			return;
		}

		textbox.text = "Rest";
		exerciseIcon.enabled = false;
		// reset timer
		timer.setTimer (currentEx.restlength / 60, currentEx.restlength % 60);
		resetProgressBar (currentEx.restlength);
	}

	public void executeFinish()
	{
		isFinished = true;
		textbox.text = "You're all finished, well done!";
		nextTextbox.text = "";
		timer.hideTimer ();
		anim.Play ("Finish");

	}

	public void updateCurrent()
	{
		if (exerciseQueue.Count > 0) {
			currentEx = exerciseQueue.Dequeue ();
		}
	}

	public void resetProgressBar(int time)
	{
		progressBar.currentPercent = 0;
		progressBar.speed = 100/time;
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
