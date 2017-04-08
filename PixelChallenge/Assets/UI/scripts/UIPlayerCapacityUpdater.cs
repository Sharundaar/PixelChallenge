using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerCapacityUpdater : MonoBehaviour {

	private PlayerData PlayerData;
	public int playerId = 1;
	public GameObject canonUI;
	public GameObject punchUI;
	public GameObject runUI;
	public GameObject carryUI;

	private float currentTime = 0;

	CanonController canonController;
	PunchController punchController;
	RunController runController;
	CarryController carryController;


	void Start () {
		SimpleTestController[] players = FindObjectsOfType(typeof(SimpleTestController)) as SimpleTestController[];
		foreach (SimpleTestController player in players) {
			PlayerData = player.GetComponent<PlayerData> (); 
			if (PlayerData && PlayerData.PlayerId == playerId) {
				canonController = player.GetComponent<CanonController> ();
				punchController = player.GetComponent<PunchController> ();
				runController = player.GetComponent<RunController> ();
				carryController = player.GetComponent<CarryController> ();
				break;
			}
		}
	}

	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= 0.25) {
			currentTime = 0;
			updateUI ();
		}
	}

	private void updateUI()
	{
		if (canonUI) {
			if(canonController && canonController.canUseCanon() & !canonController.isUsingCanon())
			{
				updateImg (canonUI, true);
			}
			else
			{
				updateImg (canonUI, false);
			}
		}

		if (runUI) {
			if (runController != null && runController.CanRun () && !runController.isRunning) {
				updateImg (runUI, true);
			} else {
				updateImg (runUI, false);
			}
				
		}

		if (punchUI) {
			if (punchController != null && punchController.CanPunch()) {
				updateImg (punchUI, true);
			} else {
				updateImg (punchUI, false);
			}

		}
	}

	private void updateImg(GameObject uiObject, bool show)
	{
		Image image = uiObject.GetComponent<Image>();
		if (show)
			image.color = Color.white;
		else
			image.color = Color.red;
	}
}
