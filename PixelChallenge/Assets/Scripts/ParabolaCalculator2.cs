using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaCalculator2
{
	public Vector3 pStart, vStart;
	public float g = -9.81f;

	public Vector3 GetPoint(float t)
	{
		return g / 2.0f * t * t * Vector3.up + vStart * t + pStart;
	}

	public Vector3 GetSpeed(float t)
	{
		return g * t * Vector3.up + vStart;
	}
}
