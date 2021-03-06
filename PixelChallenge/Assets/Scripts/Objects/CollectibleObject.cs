﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour {

	public int points = 1;

	public float lifeTime = 100;
	private float currentLifeTime = 0;

	private bool isTaken = false;
	private bool isInPlayerArea = false;


	void Start () {
		ResetTimer ();
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
		ResetTimer ();
	}

	public void TakeObject()
	{
		isTaken = true;
	}

	public void ReleaseObject()
	{
		isTaken = false;
		ResetTimer();
	}

	private void ResetTimer()
	{
		currentLifeTime = lifeTime;
	}

}
