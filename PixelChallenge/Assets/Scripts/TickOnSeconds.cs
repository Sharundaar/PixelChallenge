using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickOnSeconds : MonoBehaviour {
	
	public static string EVENT_TICK = "EVENT_TICK";

	public float numberOfSecondsBetweenTicks = 1;

	private float currentTime = 0;

	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= numberOfSecondsBetweenTicks) {
			currentTime = 0;
			EventManager.TriggerEvent (TickOnSeconds.EVENT_TICK);
		}
	}


}
