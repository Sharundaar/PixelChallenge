using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager current;
	public GameObject ScoreUI;
	public FightCountdown fightCountdown;

	private List<PlayerData> playersData;
	private SimpleTestController[] playersControllers;
	private Countdown counter;

	private PlayerData playersData1;
	private PlayerData playersData2;

	[SerializeField]
	private Text resultText;

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

			if (playerData.PlayerId == 1)
				playersData1 = playerData;
			else if (playerData.PlayerId == 2)
				playersData2 = playerData;

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

		foreach (SimpleTestController playerController in playersControllers) {
			playerController.enabled = false;
			//playerController.gameObject.SetActive(false);
		}

		int score1 = playersData1.PlayerArea.RecalculatePoints ();
		int score2 = playersData2.PlayerArea.RecalculatePoints ();

		ScoreUI.SetActive(false);
		resultText.gameObject.SetActive(true);
		if (score1 == score2) {
			EventManager.TriggerEvent ("MainCamera");
			resultText.text = "It's a draw !";
			resultText.color = new Color(246, 254, 0);
		} else if (score1 > score2) {
			EventManager.TriggerEvent ("CameraPlayer1");
			resultText.text = "Congrats player 1 !";
			resultText.color = new Color(5, 254, 5);
		} else {
			EventManager.TriggerEvent ("CameraPlayer2");
			resultText.text = "Congrats player 2 !";
			resultText.color = new Color(254, 5, 5);
		}

		StartCoroutine(ReturnToMenu());
		
	}

	IEnumerator ReturnToMenu()
	{
		float timer = 0;
		while(timer < 5.0f)
		{
            if (Input.anyKeyDown)
                break;

			timer += Time.deltaTime;
			yield return null;
		}

        
        SceneManager.LoadScene(0);
        OnlyOneUI.ui.GetComponent<ShowPanels>().ShowMenu();
        Destroy(gameObject);
	}
}
