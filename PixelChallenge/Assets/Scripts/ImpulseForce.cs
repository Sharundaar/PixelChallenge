using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseForce : MonoBehaviour {

	private float currentTime = 0;
	public Vector3 force;
	public float duration;

	// Use this for initialization
	void Awake () {

		GetComponent<SimpleTestController> ().enabled = false;
		GetComponentInChildren<Animator>().SetTrigger("Hurt");
	}

	public void SetForceAndDuration(Vector3 vector, float durationTime)
	{
		force = vector;
		duration = durationTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (force == Vector3.zero)
			return;
		
		currentTime += Time.deltaTime;

		Vector3 move = force;
		transform.position += move * Time.deltaTime;

		if (currentTime >= 0.5) {
			currentTime = 0;
			GetComponent<SimpleTestController> ().enabled = true;
			Destroy(this);
		}
	}
}
