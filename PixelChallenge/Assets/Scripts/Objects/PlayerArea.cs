using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour {

	public int playerId;
	public int currentScore;

	private List<CollectibleObject> objects = new List<CollectibleObject>();

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
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
			objects.Add (collectible);
			currentScore += collectible.points;
			return;
		} 

		var playerData = collider.GetComponentInParent<PlayerData> ();
		if (playerData && playerData.PlayerId != playerId) {
			Vector3 forceDirection = (collider.transform.position - transform.position);
			forceDirection.Normalize ();
			ImpulseForce force = playerData.gameObject.AddComponent<ImpulseForce> ();
			force.SetForceAndDuration (forceDirection * 10, 0.5f);
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
