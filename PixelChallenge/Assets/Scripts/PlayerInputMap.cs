using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMap : MonoBehaviour {

	private PlayerData player;

	[Serializable]
	struct Buttons
	{
		public string Carry;
		public string Run;
		public string Punch;
		public string MoveXAxis;
		public string MoveYAxis;
		public string RotateXAxis;
		public string RotateYAxis;
	}

	[SerializeField]
	private Buttons buttons;
	
	public string Carry
	{
		get { return "Xbox360_" + buttons.Carry + "_" + player.PlayerId; }
	}

	public string Run
	{
		get { return "Xbox360_" + buttons.Run + "_" + player.PlayerId; }
	}

	public string Punch
	{
		get { return "Xbox360_" + buttons.Punch + "_" + player.PlayerId; }
	}

	public string MoveXAxis
	{
		get { return "Xbox360_" + buttons.MoveXAxis + "_" + player.PlayerId; }
	}

	public string MoveYAxis
	{
		get { return "Xbox360_" + buttons.MoveYAxis + "_" + player.PlayerId; }
	}

	public string RotateXAxis
	{
		get { return "Xbox360_" + buttons.RotateXAxis + "_" + player.PlayerId; }
	}

	public string RotateYAxis
	{
		get { return "Xbox360_" + buttons.RotateYAxis + "_" + player.PlayerId; }
	}

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerData>();
	}
}
