using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour {

	[SerializeField]
	private Transform indicationSphere;

	[SerializeField]
	private float activationRange = 2.0f;

	private PlayerInputMap inputMap;

	private Canon canon = null;

	// Use this for initialization
	void Start () {
		inputMap = GetComponent<PlayerInputMap>();
	}

	// Update is called once per frame
	void Update() {
		Canon canon = null;

		if(this.canon != null)
		{
			HandleCanon();
			return;
		}

		var colliders = Physics.OverlapSphere(transform.position, activationRange);
		for (int i = 0; i < colliders.Length; ++i)
		{
			canon = colliders[i].GetComponent<Canon>();
			if (canon)
				break;
		}

		if (indicationSphere) {
			if (canon) {
				indicationSphere.gameObject.SetActive (true);
				indicationSphere.position = canon.transform.position + Vector3.up * 5.0f;
			} else
				indicationSphere.gameObject.SetActive (false);
		}
		


		if (canon && Input.GetButtonDown(inputMap.Activate))
		{
			GetComponent<SimpleTestController>().enabled = false;
			GetComponent<CarryController>().enabled = false;
			this.canon = canon;
		}
	}

	void HandleCanon()
	{
		if(Input.GetButtonDown(inputMap.Activate))
		{
			GetComponent<SimpleTestController>().enabled = true;
			GetComponent<CarryController>().enabled = true;
			canon = null;
			return;
		}

		if (Input.GetButtonDown(inputMap.Carry))
			canon.Fire();

		float xaxis = Input.GetAxis(inputMap.MoveXAxis);
		float yaxis = Input.GetAxis(inputMap.MoveYAxis);
		float rotAxis = Input.GetAxis(inputMap.RotateYAxis);

		canon.Angle += rotAxis;
		canon.Hazimut += -yaxis;
		canon.power += xaxis;
	}

	public bool isUsingCanon()
	{
		return canon != null;
	}
}
