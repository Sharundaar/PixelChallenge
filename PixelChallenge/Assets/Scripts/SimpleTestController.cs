using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class SimpleTestController : MonoBehaviour {

	Animator animator;

	[SerializeField]
	float xspeed = 2.0f;

	[SerializeField]
	float yspeed = 2.0f;

	public float speedBoost = 1;
	public Vector3 move = Vector3.zero;

	private PlayerInputMap inputMap;

	void Start()
	{
		inputMap = GetComponent<PlayerInputMap>();
		animator = GetComponentInChildren<Animator>();
	}

	void Update () {
		float xaxis = Input.GetAxis(inputMap.MoveXAxis);
		float yaxis = Input.GetAxis(inputMap.MoveYAxis);

		if(xaxis < 0)
		{
			var scale = animator.transform.localScale;
			scale.x = -Mathf.Abs(scale.x);
			animator.transform.localScale = scale;
		}
		else if(xaxis > 0)
		{
			var scale = animator.transform.localScale;
			scale.x = Mathf.Abs(scale.x);
			animator.transform.localScale = scale;
		}

		move = transform.right * xaxis * xspeed * speedBoost - transform.forward * yaxis * yspeed * speedBoost;
		transform.position += move * Time.deltaTime;

		GetComponent<Rigidbody>().velocity = Vector3.zero;

		if (xaxis != 0 || yaxis != 0)
			animator.SetBool("Walk", true);
		else
			animator.SetBool("Walk", false);
	}

	public void SetSpeedBoost(float value)
	{
		speedBoost = value;
	}
	public void ResetSpeedBoost()
	{
		speedBoost = 1;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}
