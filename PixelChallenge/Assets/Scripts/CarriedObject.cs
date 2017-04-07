using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriedObject : MonoBehaviour {

	public Transform carryPoint = null;
	
	// Update is called once per frame
	void Update () {
		if (carryPoint == null)
			return;

		transform.position = carryPoint.position;
		transform.rotation = carryPoint.rotation;
	}
}
