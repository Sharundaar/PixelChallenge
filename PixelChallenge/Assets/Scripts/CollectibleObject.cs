using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour {

	public int points = 1;

	public float lifeTime = 10;
	private float currentLifeTime = 0;

	private bool isTaken = false;
	private bool isInPlayerArea = false;


	void Start () {
		currentLifeTime = lifeTime;
	}

	void Update () {
		if (isTaken || isInPlayerArea)
			return;
		currentLifeTime -= Time.deltaTime;

		if (currentLifeTime <= 0) {
			Destroy (gameObject);
		}
	}

	public bool IsTaken()
	{
		return isTaken;
	}

	public bool IsInPlayerArea()
	{
		return isInPlayerArea;
	}

	public void SetIsInPlayerArea(bool isInArea)
	{
		isInPlayerArea = isInArea;
	}

	public void TakeObject()
	{
		isTaken = true;
	}

	public void ReleaseObject()
	{
		isTaken = false;
		currentLifeTime = lifeTime;
	}

}
