using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParabolaFromChild : MonoBehaviour {

	private ParabolaCalculator calculator;

	// Use this for initialization
	void Start () {
		calculator = GetComponent<ParabolaCalculator>();
	}
	
	// Update is called once per frame
	void Update () {
		calculator.PStart = transform.position;
		calculator.TStart = transform.GetChild(0).position;
		calculator.TEnd = transform.GetChild(1).position;
		calculator.PEnd = transform.GetChild(2).position;
		calculator.RecalculateBezier();
	}
}
