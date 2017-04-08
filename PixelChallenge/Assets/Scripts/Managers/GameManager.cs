using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager current;
	public GameObject ScoreUI;
	public FightCountdown fightCountdown;

	private List<PlayerData> playersData;
	private SimpleTestController[] playersControllers;
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


	}

	void Start()
	{
		InitGame();
	}
		
	void InitGame()
	{
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

		playersControllers = FindObjectsOfType(typeof(SimpleTestController)) as SimpleTestController[];
		foreach (SimpleTestController playerController in playersControllers) {
			playerController.enabled = false;
		}

		EventManager.StartListening ("StartGame", StartGame);
		fightCountdown.StartCountdown ();
	}

	public void StartGame () {
		ScoreUI.SetActive (true);

		foreach (SimpleTestController playerController in playersControllers) {
			playerController.enabled = true;
		}

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
