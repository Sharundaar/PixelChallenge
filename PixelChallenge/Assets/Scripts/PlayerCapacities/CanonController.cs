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

	private bool useCanon = false;

	// Use this for initialization
	void Start () {
		inputMap = GetComponent<PlayerInputMap>();
	}

	// Update is called once per frame
	void Update() {
		if (useCanon && this.canon != null) {
			HandleCanon ();
			return;
		}

		if (indicationSphere) {
			if (canon && canon.canFire) {
				indicationSphere.gameObject.SetActive (true);
				indicationSphere.position = canon.transform.position + Vector3.up * 5.0f;
			} else
				indicationSphere.gameObject.SetActive (false);
		}
		


		if (canon && Input.GetButtonDown(inputMap.Activate) && canon.canFire)
		{
			useCanon = true;

			GetComponent<SimpleTestController>().enabled = false;
			GetComponent<CarryController>().enabled = false;
			canon.GetComponent<CanonTrajectory>().showPreview = true;
			this.canon = canon;
			StartCoroutine(MoveCamera());
		}
	}

	IEnumerator MoveCamera()
	{
		var camera = GetComponentInChildren<Camera>();
		var preview = canon.GetComponent<CanonTrajectory>().preview;
		var deltaVec = camera.transform.localPosition;
		while (canon != null && !Input.GetButtonDown(inputMap.Carry))
		{ 
			var targetPos = preview.position + deltaVec;
			var currentPos = camera.transform.position;
			var delta = targetPos - currentPos;

			camera.transform.position = camera.transform.position + delta.normalized * Mathf.Min(delta.magnitude, 75.0f);
			yield return null;
		}

		camera.transform.localPosition = deltaVec;
	}

	void HandleCanon()
	{
		if (Input.GetButtonDown (inputMap.Activate)) {
			canon.Fire ();
			AudioManager.instance.PlaySound ("canon"+GetComponent<PlayerData> ().PlayerId);
		}

		bool stop = Input.GetButtonDown(inputMap.Carry);
		if (stop || !canon.canFire)
		{
			// deactivate canon
			useCanon = false;
			GetComponent<SimpleTestController>().enabled = true;
			GetComponent<CarryController>().enabled = true;
			canon.GetComponent<CanonTrajectory>().showPreview = false;
			if(!stop)
				canon = null;
			return;
		}

		float xaxis = Input.GetAxis(inputMap.MoveYAxis);
		float yaxis = Input.GetAxis(inputMap.MoveXAxis);

		canon.Angle += xaxis;
		canon.Hazimut += yaxis;
	}

	public bool isUsingCanon()
	{
		return canon != null && useCanon;
	}


	public bool canUseCanon()
	{
		return canon != null;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(canon == null)
			canon = collider.GetComponentInParent<Canon>();
	}

	void OnTriggerExit(Collider collider)
	{
		var c = collider.GetComponentInParent<Canon>();
		if (c == canon)
			canon = null;
	}

}
