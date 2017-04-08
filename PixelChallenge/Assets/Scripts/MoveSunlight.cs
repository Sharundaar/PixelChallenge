using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSunlight : MonoBehaviour {

	Animator animator;
	void Start () {
		animator = GetComponent<Animator>();
		EventManager.StartListening ("StartGame", StartMovement);
	}

	private void StartMovement () {
		animator.Play ("SunAnim");
	}
}
