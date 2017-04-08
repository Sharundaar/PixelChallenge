using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {


	public GameObject mainCamera;
	public GameObject player1;
	public GameObject player2;

	public GameObject player1Prefab;
	public GameObject player2Prefab;

	void Start () {
		switchToMainCamera ();
		EventManager.StartListening ("MainCamera", switchToMainCamera);
		EventManager.StartListening ("SplitScreen", switchToSplitScreen);
		EventManager.StartListening ("CameraPlayer1", switchToPlayer1);
		EventManager.StartListening ("CameraPlayer2", switchToPlayer2);

		EventManager.StartListening ("StartGame", switchToSplitScreen);
	}

	public void switchToMainCamera () {
		if (!AreCamerasDefined ())
			return;
		mainCamera.SetActive (true);
		player1.SetActive (false);
		player2.SetActive (false);
		player1Prefab.SetActive (false);
		player2Prefab.SetActive (false);
	}
		
	public void switchToSplitScreen () {
		if (!AreCamerasDefined ())
			return;
		Debug.Log ("Change");
		mainCamera.SetActive (false);
		player1.SetActive (false);
		player2.SetActive (false);
		player1Prefab.SetActive (true);
		player2Prefab.SetActive (true);
	}
		
	public void switchToPlayer1 () {
		if (!AreCamerasDefined ())
			return;
		mainCamera.SetActive (false);
		player1.SetActive (true);
		player2.SetActive (false);
		player1Prefab.SetActive (false);
		player2Prefab.SetActive (false);
	}

	public void switchToPlayer2 () {
		if (!AreCamerasDefined ())
			return;
		mainCamera.SetActive (false);
		player1.SetActive (false);
		player2.SetActive (true);
		player1Prefab.SetActive (false);
		player2Prefab.SetActive (false);
	}

	public bool AreCamerasDefined () {
		return mainCamera != null && player1 != null && player2 != null;
	}


}
