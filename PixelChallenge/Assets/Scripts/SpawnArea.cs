using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

	public List<CollectibleObject> spawnableObjects = new List<CollectibleObject>();
	public CollectibleObject spawnableObject;
	private Bounds bounds;

	public float cooldownSpawnMin = 0.5f;
	public float cooldownSpawnMax = 2.5f;
	public float maxObjectsInSpawn = 6;

	private float currentTime = 0;
	private float cooldownSpawn = 0;
	private int objectsInSpawnCount = 0;
	public List<CollectibleObject> objectsInSpawn = new List<CollectibleObject>();

	private bool isSpawning;

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
		Transform newObject = Instantiate (spawnableObject.gameObject.transform, SetPositionOnTop(GetRandomPosition ()), Quaternion.identity);
		//newObject.parent = gameObject.transform;
		return newObject;
	}

	public Vector3 GetRandomPosition()
	{
		return new Vector3 (Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z) );
	}

	public Vector3 SetPositionOnTop(Vector3 vector)
	{
		vector.y = bounds.max.y;
		return vector;
	}

	public Vector3 SetPositionOnGround(Vector3 vector)
	{
		vector.y = bounds.min.y;
		return vector;
	}

	public void StartSpawning()
	{
		isSpawning = true;
	}

	public void StopSpawning()
	{
		isSpawning = false;
	}


	void OnTriggerEnter(Collider collider)
	{
		var collectible = collider.GetComponent<CollectibleObject> ();
		if (collectible) {
			objectsInSpawn.Add ( collectible );
			objectsInSpawnCount++;
		}

	}

	void OnTriggerStay(Collider collider)
	{

	}

	void OnTriggerExit(Collider collider)
	{
		var collectible = collider.GetComponent<CollectibleObject> ();
		if (collectible) {
			objectsInSpawn.Remove (collectible);
			objectsInSpawnCount--;
		}
	}


	// Update is called once per frame
	void Update () {
		if (!isSpawning)
			return;
		currentTime += Time.deltaTime;
		if (currentTime >= cooldownSpawn) {
			currentTime = 0;
			cooldownSpawn = Random.Range (cooldownSpawnMin, cooldownSpawnMax);
			if (objectsInSpawnCount > maxObjectsInSpawn) {
				return;
			}
			SpawnObject ();
		}
	}
}
