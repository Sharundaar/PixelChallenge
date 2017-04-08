using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrajectory : MonoBehaviour {

	public ParabolaCalculator2 trajectory;

	private float t;

	public bool stopFollowOnHit = true;

	public float timeMultiplicator = 1.0f;

	public float protectionTime = 1.5f;

	private void Start()
	{
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<Collider>().isTrigger = true;
	}

	private void Update()
	{
		var pos = trajectory.GetPoint(t);
		transform.position = pos;

		t += Time.deltaTime * timeMultiplicator;
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (t < protectionTime)
			return;

		if (!stopFollowOnHit)
			return;

		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Collider>().isTrigger = false;
		GetComponent<Rigidbody>().velocity = trajectory.GetSpeed(t);
		Destroy(this);
	}
	
}
