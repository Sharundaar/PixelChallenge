using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager current;
	public GameObject ScoreUI;

	private List<PlayerData> playersData;
	private Countdown counter;

	public List<PlayerData> PlayersData
	{
		get
		{
			return playersData;
		}
	}

	void Awake()
	{
		if (current == null)
			current = this;
		else if (current != this)
			Destroy(gameObject);    
		
		DontDestroyOnLoad(gameObject);

		InitGame();
	}
		
	void InitGame()
	{
		EventManager.StartListening (Countdown.COUNTER_ENDED, CounterEnded);
		EventManager.StartListening (TickOnSeconds.EVENT_TICK, OnTick);

		playersData = new List<PlayerData> ();
		PlayerData[] playersDatas = FindObjectsOfType(typeof(PlayerData)) as PlayerData[];
		PlayerArea[] playersAreas = FindObjectsOfType(typeof(PlayerArea)) as PlayerArea[];
		foreach (PlayerData playerData in playersDatas) {
			Debug.Log ("playerdata");
			playersData.Add (playerData);

			foreach (PlayerArea playerArea in playersAreas) {
				if (playerArea.playerId == playerData.PlayerId) {
					Debug.Log ("affect");
					playerData.PlayerArea = playerArea;
				}
			}
		}

		StartGame ();
	}

	public void StartGame () {
		counter = GetComponent<Countdown> ();
		counter.StartCounter ();
	}

	private void OnTick () {
		Debug.Log("Current time : "+counter.GetTimeInStr());
	}

	public void CounterEnded () {
		EventManager.StopListening (Countdown.COUNTER_ENDED, CounterEnded);
		CountPoints ();
	}

	public void CountPoints () {
		
	}
}
