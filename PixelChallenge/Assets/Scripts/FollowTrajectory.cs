using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrajectory : MonoBehaviour {

	public ParabolaCalculator2 trajectory;

	private float t;

	public bool stopFollowOnHit = true;

	private void Start()
	{
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<Collider>().isTrigger = true;
	}

	private void Update()
	{
		var pos = trajectory.GetPoint(t);
		transform.position = pos;

		t += Time.deltaTime;
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (!stopFollowOnHit)
			return;

		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Collider>().isTrigger = false;
		Destroy(this);
	}
	
}
