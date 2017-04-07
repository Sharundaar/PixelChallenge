using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class SimpleTestController : MonoBehaviour {

	[SerializeField]
	float xspeed = 2.0f;

	[SerializeField]
	float yspeed = 2.0f;

	public float speedBoost = 1;

	private PlayerInputMap inputMap;

	void Start()
	{
		inputMap = GetComponent<PlayerInputMap>();
	}

	void Update () {
		float xaxis = Input.GetAxis(inputMap.MoveXAxis);
		float yaxis = Input.GetAxis(inputMap.MoveYAxis);

		Vector3 move = transform.right * xaxis * xspeed * speedBoost - transform.forward * yaxis * yspeed * speedBoost;
		transform.position += move * Time.deltaTime;
	}

	public void SetSpeedBoost(float value)
	{
		speedBoost = value;
	}
	public void ResetSpeedBoost()
	{
		speedBoost = 1;
	}
}
