using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public string scene;

	public void GotoScene ()
	{
		if (scene == "Menu") {
			DestroySystem ();
		}
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
		
	}

	public void DestroySystem()
	{
		Destroy (GameObject.FindGameObjectWithTag ("System"));
	}

}
