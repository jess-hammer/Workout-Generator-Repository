using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowWithTime : MonoBehaviour
{
	[SerializeField]
	private float totalTimeLeft;

	[Space]
	public Vector3 targetPos;
	private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
		//totalTimeLeft = UserPrefs.durationMin * 60;
		pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		//pos = this.transform.position;
		pos.y -= (pos.y - targetPos.y) / totalTimeLeft;
		transform.position = pos;
		totalTimeLeft -= Time.deltaTime;
    }
}
