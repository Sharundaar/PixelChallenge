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

		EventManager.StartListening ("MainCamera", switchToMainCamera);
		EventManager.StartListening ("SplitScreen", switchToSplitScreen);
		EventManager.StartListening ("CameraPlayer1", switchToPlayer1);
		EventManager.StartListening ("CameraPlayer2", switchToPlayer2);
	}

	private void switchToMainCamera () {
		if (!areCameraDefined ())
			return;
		mainCamera.SetActive (true);
		player1.SetActive (false);
		player2.SetActive (false);
		player1Prefab.SetActive (false);
		player2Prefab.SetActive (false);
	}
		
	private void switchToSplitScreen () {
		if (!areCameraDefined ())
			return;
		mainCamera.SetActive (false);
		player1.SetActive (false);
		player2.SetActive (false);
		player1Prefab.SetActive (true);
		player2Prefab.SetActive (true);
	}
		
	private void switchToPlayer1 () {
		if (!areCameraDefined ())
			return;
		mainCamera.SetActive (false);
		player1.SetActive (true);
		player2.SetActive (false);
		player1Prefab.SetActive (false);
		player2Prefab.SetActive (false);
	}

	private void switchToPlayer2 () {
		if (!areCameraDefined ())
			return;
		mainCamera.SetActive (false);
		player1.SetActive (false);
		player2.SetActive (true);
		player1Prefab.SetActive (false);
		player2Prefab.SetActive (false);
	}

	private bool areCameraDefined () {
		return mainCamera != null && player1 != null && player2 != null;
	}


}
