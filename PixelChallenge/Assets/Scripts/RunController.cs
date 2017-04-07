﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController : MonoBehaviour {

	private PlayerInputMap inputMap;
	public bool isRunning;
	public float runDuration;
	public float runMaxDuration = 1.5f;
	public float runResetCooldownDuration = 15.0f;

	void Start()
	{
		inputMap = GetComponent<PlayerInputMap>();
	}

	void Update () {
		if (Input.GetButtonDown (inputMap.Run) || isRunning) {
			Run ();
		} else if (runDuration > 0) { // retrieve energy
			runDuration -= Time.deltaTime;
		} else {
			runDuration = 0;
		}
	}

	private void Run()
	{
		if (isRunning) {
			runDuration += Time.deltaTime;
			if (!CanRun ()) {
				StopRunning ();
			}
			return;
		} else if (runDuration == 0) {
			isRunning = true;
			GetComponent<SimpleTestController> ().SetSpeedBoost (1.5f);
		}
	}

	private void StopRunning()
	{
		Debug.Log ("StopRunning");
		isRunning = false;
		runDuration = runResetCooldownDuration;
		GetComponent<SimpleTestController> ().ResetSpeedBoost ();
	}

	private bool CanRun()
	{
		return !(runDuration >= runMaxDuration);
	}
}
