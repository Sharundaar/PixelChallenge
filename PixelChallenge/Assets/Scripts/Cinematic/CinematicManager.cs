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
		yield return new WaitForSeconds(3.2f);
		SceneManager.LoadScene (2);
		yield return null;
	}
}
