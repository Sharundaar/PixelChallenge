using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {


	public float durationInSeconds = 5 * 60;
	private float currentTime = 0;


	public void StartCounter () {
		currentTime = durationInSeconds;
	}


	void Update () {
		currentTime -= Time.deltaTime;
		if (currentTime <= 0) {
			CounterEnded ();
		}
	}

	public void CounterEnded ()
	{
		
	}
}
