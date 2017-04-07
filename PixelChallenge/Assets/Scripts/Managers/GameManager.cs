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
		if(ScoreUI)
			ScoreUI.SetActive (false);
		EventManager.StartListening (Countdown.COUNTER_ENDED, CounterEnded);
		EventManager.StartListening (TickOnSeconds.EVENT_TICK, OnTick);

		playersData = new List<PlayerData> ();
		PlayerData[] playersDatas = FindObjectsOfType(typeof(PlayerData)) as PlayerData[];
		PlayerArea[] playersAreas = FindObjectsOfType(typeof(PlayerArea)) as PlayerArea[];
		foreach (PlayerData playerData in playersDatas) {
			playersData.Add (playerData);

			foreach (PlayerArea playerArea in playersAreas) {
				if (playerArea.playerId == playerData.PlayerId) {
					playerData.PlayerArea = playerArea;
				}
			}
		}

		StartGame ();
	}

	public void StartGame () {
		counter = GetComponent<Countdown> ();
		counter.StartCounter ();

		if(ScoreUI)
			ScoreUI.SetActive (true);

		SpawnArea[] spawnsAreas = FindObjectsOfType(typeof(SpawnArea)) as SpawnArea[];
		foreach (SpawnArea spawnArea in spawnsAreas) {
			spawnArea.StartSpawning ();
		}
	}

	private void OnTick () {

	}

	private void CounterEnded () {
		EventManager.StopListening (Countdown.COUNTER_ENDED, CounterEnded);
		EndGame ();
	}

	public void EndGame () {
		SpawnArea[] spawnsAreas = FindObjectsOfType(typeof(SpawnArea)) as SpawnArea[];
		foreach (SpawnArea spawnArea in spawnsAreas) {
			spawnArea.StopSpawning ();
		}
		
	}
}
