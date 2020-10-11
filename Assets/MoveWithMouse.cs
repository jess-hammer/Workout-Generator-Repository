using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
	public float scale = 1;
	private float initialPos;

	private void Start ()
	{
		initialPos = transform.position.x;
	}



	// Update is called once per frame
	void Update()
    {
		float amount = Input.mousePosition.x;
		transform.position = new Vector3 (initialPos + (scale / 10) * amount, transform.position.y, transform.position.z);
		
    }
}
