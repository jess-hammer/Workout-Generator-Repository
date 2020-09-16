using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public void GotoMainScreen ()
	{
		SceneManager.LoadScene ("MainScreen", LoadSceneMode.Single);
	}

	public void GotoOverview ()
	{
		SceneManager.LoadScene ("Overview", LoadSceneMode.Single);
	}

	public void GotoMenu ()
	{
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}
}
