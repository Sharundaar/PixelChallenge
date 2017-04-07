using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollowCamera : MonoBehaviour {

	[SerializeField]
	private Transform target;

	private Vector3 initialTargetDelta;
	


	// Use this for initialization
	void Start () {
		initialTargetDelta = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position + initialTargetDelta;
	}
}
