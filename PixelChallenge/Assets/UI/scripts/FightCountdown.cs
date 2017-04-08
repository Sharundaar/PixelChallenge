using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCountdown : MonoBehaviour {
	public GameObject UI_3;
	public GameObject UI_2;
	public GameObject UI_1;
	public GameObject UI_FIGHT;

	private float currentTime = 0;


	void Start()
	{
		UI_3.SetActive (false);
		UI_2.SetActive (false);
		UI_1.SetActive (false);
		UI_FIGHT.SetActive (false);
		StartCoroutine(StartAnimationCoroutine());
    }

	public void StartCountdown()
	{
		
	}

	IEnumerator StartAnimationCoroutine()
	{
		yield return new WaitForSeconds(1);
		UI_3.SetActive (true);
		AudioManager.instance.PlaySound ("UI_3");
        yield return new WaitForSeconds(1);
		UI_3.SetActive (false);
		UI_2.SetActive (true);
		AudioManager.instance.PlaySound ("UI_2");
		yield return new WaitForSeconds(1);
		UI_2.SetActive (false);
		UI_1.SetActive (true);
		AudioManager.instance.PlaySound ("UI_1");
		yield return new WaitForSeconds(1);
		UI_1.SetActive (false);
		UI_FIGHT.SetActive (true);
		AudioManager.instance.PlaySound ("UI_FIGHT");
		yield return new WaitForSeconds(1);
		UI_FIGHT.SetActive (false);
		yield return null;
		EventManager.TriggerEvent ("StartGame");
    }


}
