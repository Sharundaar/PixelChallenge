using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectOnCollision : MonoBehaviour {

	public GameObject elementToHide;

	void OnTriggerEnter(Collider collider)
	{
		var playerController = collider.GetComponentInParent<SimpleTestController> ();
		Debug.Log (playerController);
		if (playerController && elementToHide) {
			elementToHide.SetActive (true);
		}
	}

	void OnTriggerStay(Collider collider)
	{
		var canonController = collider.GetComponentInParent<CanonController> ();
		if (canonController && elementToHide && canonController.isUsingCanon()) {
			elementToHide.SetActive (false);
		}
	}

	void OnTriggerExit(Collider collider)
	{
		var playerController = collider.GetComponentInParent<SimpleTestController> ();
		if (playerController && elementToHide) {
			elementToHide.SetActive (false);
		}
	}
}
