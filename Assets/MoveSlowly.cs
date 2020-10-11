using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlowly : MonoBehaviour
{
	public float amount = 1;
	public float rightBound;
	public float leftBound;
	public bool goingRight = true;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.x >= rightBound) {
			goingRight = false;
		}

		if (transform.position.x <= leftBound) {
			goingRight = true;
		}

		if (goingRight) {
			transform.position = new Vector3 (transform.position.x + (amount / 100) * amount, transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 (transform.position.x - (amount / 100) * amount, transform.position.y, transform.position.z);
		}
		
	}
}
