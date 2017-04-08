using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(StartAnimationCoroutine());
	}

	IEnumerator StartAnimationCoroutine()
	{
		Debug.Log ("lol");
		yield return new WaitForSeconds(1);
		Debug.Log ("lol1");
		//AudioManager.instance.PlaySound ("UI_FIGHT");
		yield return new WaitForSeconds(1);
		Debug.Log ("lol2");
		SceneManager.LoadScene (2);
		yield return null;
	}
}
