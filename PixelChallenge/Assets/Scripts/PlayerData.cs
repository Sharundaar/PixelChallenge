using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	[SerializeField]
	private string playerId = "1";

	public string PlayerId
	{
		get { return playerId; }
	}
}
