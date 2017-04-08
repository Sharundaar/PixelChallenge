using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTrajectory : MonoBehaviour {

	private ParabolaCalculator2 calculator;

	private Canon canon;

	private LineRenderer lineRenderer;

	[SerializeField]
	public Transform preview;
	public bool showPreview = false;

	public void Start()
	{
		canon = GetComponent<Canon>();
		calculator = new ParabolaCalculator2();

		if (!showPreview)
			preview.gameObject.SetActive(false);
		else
			preview.gameObject.SetActive(true);
	}

	public void Update()
	{
		calculator.pStart = canon.CanonPivot.position;
		calculator.vStart = -canon.power * canon.CanonPivot.forward;
		calculator.g = -9.81f;

		if (!showPreview)
			preview.gameObject.SetActive(false);
		else
			preview.gameObject.SetActive(true);

		if (showPreview)
			Preview();
	}

	void Preview()
	{
		float t = -2.0f * calculator.vStart.y / calculator.g;
		var p = calculator.GetPoint(t);
		preview.position = p;
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
