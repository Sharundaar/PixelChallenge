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
		//StartCoroutine(CameraSwitchTest());
	}

	IEnumerator CameraSwitchTest()
	{
		yield return new WaitForSeconds(1.2f);
		switchToSplitScreen ();
		yield return new WaitForSeconds(1.2f);
		switchToMainCamera ();
		yield return new WaitForSeconds(1.2f);
		switchToPlayer1 ();
		yield return new WaitForSeconds(1.2f);
		switchToPlayer2 ();
		yield return new WaitForSeconds(1.2f);
		switchToSplitScreen ();
		yield return new WaitForSeconds(1.2f);
		switchToMainCamera ();
		yield return null;
	}

	public void switchToMainCamera () {
		if (!AreCamerasDefined ())
			return;
		Debug.Log ("ChangeMain");
		mainCamera.SetActive (true);
		player1.SetActive (false);
		player2.SetActive (false);
		player1Prefab.SetActive (false);
		player2Prefab.SetActive (false);
	}
		
	public void switchToSplitScreen () {
		if (!AreCamerasDefined ())
			return;
		Debug.Log ("Changesplit");
		mainCamera.SetActive (false);
		player1.SetActive (false);
		player2.SetActive (false);
		player1Prefab.SetActive (true);
		player2Prefab.SetActive (true);
	}
		
	public void switchToPlayer1 () {
		if (!AreCamerasDefined ())
			return;
		Debug.Log ("Change1");
		mainCamera.SetActive (false);
		player1.SetActive (true);
		player2.SetActive (false);
		player1Prefab.SetActive (false);
		player2Prefab.SetActive (false);
	}

	public void switchToPlayer2 () {
		if (!AreCamerasDefined ())
			return;
		Debug.Log ("Change2");
		mainCamera.SetActive (false);
		player1.SetActive (false);
		player2.SetActive (true);
		player1Prefab.SetActive (false);
		player2Prefab.SetActive (false);
	}

	public bool AreCamerasDefined () {
		return true;//mainCamera != null && player1 != null && player2 != null;
	}


}
