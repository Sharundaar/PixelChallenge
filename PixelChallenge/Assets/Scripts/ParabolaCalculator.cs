using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaCalculator : MonoBehaviour {
	[SerializeField]
	private Vector3 pStart, tStart, tEnd, pEnd;

	public Vector3 PStart { get { return pStart; } set { pStart = value; } }
	public Vector3 TStart { get { return tStart; } set { tStart = value; } }
	public Vector3 TEnd { get { return tEnd; } set { tEnd = value; } }
	public Vector3 PEnd { get { return pEnd; } set { pEnd = value; } }

	[SerializeField]
	int definition = 10;

	[HideInInspector]
	public List<Vector3> points = new List<Vector3>();

	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		RecalculateBezier();
	}

	public void RecalculateBezier()
	{
		points.Clear();
		float t;
		for (t = 0; t <= 1.0f; t += 1.0f / definition)
		{
			var point = (1 - t) * (1 - t) * (1 - t) * PStart
				+ 3 * (1 - t) * (1 - t) * t * TStart
				+ 3 * (1 - t) * t * t * TEnd
				+ t * t * t * PEnd;
			points.Add(point);
		}

		if(t != 1.0f) // always add last point
		{
			t = 1;
			var point = GetPoint(t);
			points.Add(point);
		}

		lineRenderer.positionCount = points.Count;
		lineRenderer.SetPositions(points.ToArray());
	}

	public Vector3 GetPoint(float t)
	{
		return (1 - t) * (1 - t) * (1 - t) * PStart
				+ 3 * (1 - t) * (1 - t) * t * TStart
				+ 3 * (1 - t) * t * t * TEnd
				+ t * t * t * PEnd;
	}
}
