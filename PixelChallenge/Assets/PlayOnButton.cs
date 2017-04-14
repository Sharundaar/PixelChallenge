using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnButton : MonoBehaviour {
    public GameObject checkActive;

	// Update is called once per frame
	void Update () {
        if (!checkActive.activeInHierarchy)
            return;

        if (Input.anyKey)
            GetComponent<StartOptions>().StartButtonClicked();
	}
}
