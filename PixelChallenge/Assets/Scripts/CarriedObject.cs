using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriedObject : MonoBehaviour {

	public Transform carryPoint = null;
	private RigidbodyConstraints initConstraints;

	private Vector3 initialPos;

	void Start()
	{
		Rigidbody body = GetComponent<Rigidbody>();
		body.isKinematic = true;

		if(transform.childCount > 0)
		{
			transform.GetChild(0).localPosition += Vector3.up * 0.15f;
			initialPos = transform.GetChild(0).localPosition;
		}

		CollectibleObject collectible = GetComponent<CollectibleObject> ();
		if(collectible)
			collectible.TakeObject ();
	}

	void OnDestroy()
	{
		Rigidbody body = GetComponent<Rigidbody>();
		body.isKinematic = false;

		if(transform.childCount > 0)
			transform.GetChild(0).localPosition = initialPos;

		CollectibleObject collectible = GetComponent<CollectibleObject> ();
		if(collectible)
			collectible.ReleaseObject ();
	}

	// Update is called once per frame
	void Update () {
		if (carryPoint == null)
			return;

		transform.position = carryPoint.position;
		transform.rotation = carryPoint.rotation;
	}
}
