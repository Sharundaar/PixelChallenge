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
        while(!Input.anyKeyDown)
		    yield return null;
		SceneManager.LoadScene (2);
	}
}
