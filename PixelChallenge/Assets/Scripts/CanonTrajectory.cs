using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTrajectory : MonoBehaviour {

	private ParabolaCalculator2 calculator;

	private Canon canon;

	private LineRenderer lineRenderer;

	public void Start()
	{
		canon = GetComponent<Canon>();
		calculator = new ParabolaCalculator2();
	}

	public void Update()
	{
		calculator.pStart = canon.CanonPivot.position;
		calculator.vStart = -canon.power * canon.CanonPivot.forward;
		calculator.g = -9.81f;
	}

	void Preview()
	{

	}

	public Vector3 GetPoint(float t)
	{		
		return calculator.GetPoint(t);
	}

	public ParabolaCalculator2 CopyTrajectory()
	{
		return new ParabolaCalculator2()
		{
			pStart = calculator.pStart,
			vStart = calculator.vStart,
			g = calculator.g
		};
	}

}
