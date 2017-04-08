using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerScoreUpdater : MonoBehaviour {

	private PlayerData PlayerData;
	public int playerId = 1;
	public Text scoreText;
	private float currentTime = 0;


	void Start () {
		scoreText.text = "";
		PlayerData[] playersDatas = FindObjectsOfType(typeof(PlayerData)) as PlayerData[];
		foreach (PlayerData playerData in playersDatas) {
			if (playerData.PlayerId == playerId) {
				PlayerData = playerData;
				//placeWidget ();
				break;
			}
		}
	}

	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= 0.5) {
			currentTime = 0;
			updateUI ();
		}
	}

	/*private void placeWidget()
	{
		Debug.Log ("Placed");
		RectTransform rectTransform = gameObject.transform.GetComponent<RectTransform> ();
		switch (playerData.PlayerId) {
			case 1: 
				rectTransform.SetPivot (PivotPresets.TopLeft);
				rectTransform.SetAnchor (AnchorPresets.TopLeft);
				break;			
			case 2: 
				rectTransform.SetPivot (PivotPresets.TopRight);
				rectTransform.SetAnchor (AnchorPresets.TopRight);
			break;		
			case 3: 
				rectTransform.SetPivot (PivotPresets.BottomLeft);
				rectTransform.SetAnchor (AnchorPresets.BottomLeft);
				break;		
			case 4: 
				rectTransform.SetPivot (PivotPresets.BottomRight);
				rectTransform.SetAnchor (AnchorPresets.BottomRight);
				break;
		}
	}*/

	private void updateUI()
	{
		Debug.Log (PlayerData.Score);
		if(scoreText && PlayerData)
			scoreText.text = PlayerData.Score + "";
	}
}
