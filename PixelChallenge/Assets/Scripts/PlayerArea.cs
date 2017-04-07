using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour {

	public int playerId;
	public int currentScore;

	private List<CollectibleObject> objects = new List<CollectibleObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		var collectible = collider.GetComponent<CollectibleObject> ();
		if (collectible) {
			Debug.Log ("ENTER");
			collectible.SetIsInPlayerArea (true);
			objects.Add ( collectible );
			currentScore += collectible.points;
		}
		
	}

	void OnTriggerStay(Collider collider)
	{

	}

	void OnTriggerExit(Collider collider)
	{
		var collectible = collider.GetComponent<CollectibleObject> ();
		if (collectible) {
			Debug.Log ("QUIT");
			collectible.SetIsInPlayerArea (false);
			objects.Remove (collectible);
			currentScore -= collectible.points;
		}
	}

	public int RecalculatePoints()
	{
		currentScore = 0;
		foreach (CollectibleObject collectible in objects) {
			currentScore += collectible.points;
		}
		return currentScore;
	}

	public List<CollectibleObject> GetObjects()
	{
		return objects;
	}



}
