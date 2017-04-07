using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRaycast : MonoBehaviour {

	[SerializeField]
	private LayerMask mask;
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;
		if( Physics.Raycast(ray, out hit, float.MaxValue, mask))
		{
			Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 0.5f);
		}
		else
		{
			Debug.DrawRay(ray.origin, ray.direction * 5.0f, Color.red, 0.5f);
		}
	}
}
