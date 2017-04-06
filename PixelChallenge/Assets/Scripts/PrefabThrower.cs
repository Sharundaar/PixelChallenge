using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabThrower : MonoBehaviour {

	public Rigidbody Prefab;
	public float ForceStrength;
	public float Frequency;

	private float t;
	
	int counter = 0;

	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		while( t > 1.0f / Frequency )
		{
			t -= 1.0f / Frequency;
			var go = Instantiate( Prefab, transform.position, Quaternion.identity);
			go.AddForce( transform.forward * ForceStrength, ForceMode.Impulse );
			go.name = Prefab.name + counter++;
		}
	}
}
