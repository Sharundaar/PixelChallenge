using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager current;

	List<PlayerArea> playerAreas;

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
		
		StartGame ();
	}

	public void StartGame () {
		var counter = GetComponent<Countdown> ();
		counter.StartCounter ();
	}

	public void CounterEnded () {
		CountPoints ();
	}

	public void CountPoints () {
		
		
	}

	private void GetObjectsFromZone (GameObject zone) {
		List<CollectibleObject> objects = new List<CollectibleObject>();


	}
}
