using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class SimpleTestController : MonoBehaviour {

	[SerializeField]
	float xspeed = 2.0f;

	[SerializeField]
	float yspeed = 2.0f;

	private PlayerInputMap inputMap;

	void Start()
	{
		inputMap = GetComponent<PlayerInputMap>();
	}

	void Update () {
		float xaxis = Input.GetAxis(inputMap.MoveXAxis);
		float yaxis = Input.GetAxis(inputMap.MoveYAxis);

		Vector3 move = transform.right * xaxis * xspeed - transform.forward * yaxis * yspeed;
		transform.position += move * Time.deltaTime;
	}
}
