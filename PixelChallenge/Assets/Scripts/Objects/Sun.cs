using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//transform.RotateAround (Vector3.zero, new Vector3(0.3f, 0, 1), 1);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.RotateAround (Vector3.zero, new Vector3(0.3f, 0, 1), 10f * Time.deltaTime);
		transform.RotateAround (Vector3.zero, new Vector3(0.3f, 0, 1), 10f * Time.deltaTime);

		//Vector3 objRotation = transform.rotation.eulerAngles;
		//Debug.Log (objRotation);
		//float clampedY = Mathf.Clamp (objRotation.y, -30f, 30f);
		//transform.rotation.eulerAngles = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z);
	}
}
