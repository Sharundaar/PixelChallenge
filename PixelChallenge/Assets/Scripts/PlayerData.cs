using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	[SerializeField]
	private int playerId = 1;

	private PlayerArea playerArea;

	public int PlayerId
	{
		get { return playerId; }
	}

	public int Score
	{
		get { 
			if (playerArea)
				return playerArea.currentScore;
			return 0; 
		}
	}

	public PlayerArea PlayerArea
	{
		get { return playerArea; }
		set { 
			playerArea = value;
		}
	}
}
