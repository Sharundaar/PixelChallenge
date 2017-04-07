using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

	public List<CollectibleObject> spawnableObjects = new List<CollectibleObject>();
	public CollectibleObject spawnableObject;
	private Bounds bounds;

	// Use this for initialization
	void Start () {
		BoxCollider box = GetComponent<BoxCollider> ();
		bounds = box.bounds;

		SpawnObject ();
		SpawnObject ();
		SpawnObject ();
	}

	public Transform SpawnObject()
	{
		Transform newObject = Instantiate (spawnableObject.gameObject.transform, GetRandomPosition (), Quaternion.identity);
		return newObject;
	}

	public Vector3 GetRandomPosition()
	{
		return new Vector3 (Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z) );
	}

	public Vector3 SetPositionOnGround(Vector3 vector)
	{
		vector.y = bounds.min.y;
		return vector;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
