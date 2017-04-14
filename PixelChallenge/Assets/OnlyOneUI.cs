using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyOneUI : MonoBehaviour {

    public static GameObject ui = null;

	// Use this for initialization
	void Start () {
        if (ui != null)
        {
            Destroy(gameObject);
            return;
        }
        ui = gameObject;
	}
}
