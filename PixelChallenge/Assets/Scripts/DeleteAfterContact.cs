﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterContact : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}

}
