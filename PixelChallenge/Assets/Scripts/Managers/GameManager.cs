using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager current;

	private List<PlayerArea> playerAreas;
	private Countdown counter;

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
