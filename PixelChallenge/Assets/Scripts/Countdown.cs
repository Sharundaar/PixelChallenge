using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	public static string COUNTER_ENDED = "COUNTER_ENDED";
	public float durationInSeconds = 5 * 60;
	private float currentTime = 0;
	private bool isRunning = false;


	public void StartCounter () {
		ResetCounter ();
		isRunning = true;
	}

	public void PauseCounter ()
	{
		isRunning = false;
	}

	public void StopCounter ()
	{
		isRunning = false;
		ResetCounter ();
	}

	public void ResetCounter ()
	{
		currentTime = durationInSeconds;
	}

	public float GetTime ()
	{
		return currentTime;
	}

	public string GetTimeInStr()
	{
		System.TimeSpan t = System.TimeSpan.FromSeconds (currentTime);

		return string.Format("{0:#00}:{1:00}", t.Minutes, t.Seconds);
	}


	void Update () {
		if (!isRunning)
			return;
		
		currentTime -= Time.deltaTime;
		if (currentTime <= 0) {
			currentTime = 0;
			isRunning = false;
			CounterEnded ();
		}
	}

	public void CounterEnded ()
	{
		EventManager.TriggerEvent (Countdown.COUNTER_ENDED);
	}
}
