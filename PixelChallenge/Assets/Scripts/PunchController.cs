﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour {

	private PlayerInputMap inputMap;
	private SimpleTestController playerController;
	private float currentTime = 0;
	public float punchResetCooldownDuration = 4.0f;
	public float punchForce = 300.0f;

	void Start()
	{
		inputMap = GetComponent<PlayerInputMap>();
		playerController = GetComponent<SimpleTestController> ();
	}

	void Update () {
		if (currentTime > 0) {
			currentTime -= Time.deltaTime;
		}
		else if (Input.GetButtonDown (inputMap.Punch)) {
			Punch ();
		}
	}

	private void Punch()
	{
		Debug.Log ("PUNCH");
		currentTime = punchResetCooldownDuration;
		Vector3 moveDirection = playerController.move;
		moveDirection.Normalize();

		RaycastHit hit;
		//if (Physics.Raycast (transform.position, moveDirection, out hit, 100.0f)) {

		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5.0f);
		int i = 0;
		Collider collider;
		while (i < hitColliders.Length)
		{
			collider = hitColliders [i];
			if (collider.transform.root == transform) {
				Debug.Log ("player");
				i++;
				continue;
			}
			Debug.Log (collider);
			Rigidbody rigidBody = collider.GetComponentInParent<Rigidbody> ();
			if (rigidBody) {
				Vector3 direction = rigidBody.position - transform.position;
				direction.Normalize ();

				SimpleTestController controller = collider.GetComponentInParent<SimpleTestController> ();
				if(controller)
				{
					
					ImpulseForce force = controller.gameObject.AddComponent<ImpulseForce> ();
					force.SetForceAndDuration (direction * 15, 1.5f);
					Debug.Log ("player FUSROHDAH");
				}
				else if(collider.GetComponentInParent<CollectibleObject> ())
				{
					rigidBody.AddForce (direction * punchForce, ForceMode.Impulse);
				}
			}
			i++;
		}

	}
}
