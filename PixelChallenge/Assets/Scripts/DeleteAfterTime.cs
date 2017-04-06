using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour {

	public float TimeLimit;

	private float tAcc = 0;

	// Update is called once per frame
	void Update () {
		tAcc += Time.deltaTime;
		if(tAcc >= TimeLimit)
		{
			Destroy(gameObject);
		}
	}
}
