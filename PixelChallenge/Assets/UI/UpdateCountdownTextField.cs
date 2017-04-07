using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCountdownTextField : MonoBehaviour {

	private float currentTime = 0;
	public Text textComponent;

	private Countdown countdown;

	void Start()
	{
		countdown = GetComponent<Countdown> ();
	}

	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= 0.5) {
			currentTime = 0;
			if(textComponent)
				textComponent.text = countdown.GetTimeInStr();
		}
	}
}
