using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

	[SerializeField]
	private Transform sceneCenter;

	[SerializeField]
	private float minRadius = 10.0f;

	private Camera cameraComp;

	private float targetRadius = 0;

	[SerializeField]
	private float padding = 15.0f;

	void Start () {
		targetRadius = Vector3.Distance(sceneCenter.position, transform.position);
		cameraComp = GetComponent<Camera>();

		transform.forward = sceneCenter.position - transform.position;
	}
	
	void Update () {

		float maxDist = 0;
		for(int i=0; i<GameManager.current.PlayersData.Count; ++i)
		{
			var player = GameManager.current.PlayersData[i];
			var vect = Vector3.ProjectOnPlane(player.transform.position - sceneCenter.position, transform.forward);
			float dist = vect.magnitude + padding;

			if (dist > maxDist)
				maxDist = dist;
		}

		targetRadius = maxDist/  Mathf.Tan( cameraComp.fieldOfView / 2.0f * Mathf.Deg2Rad );
		if (targetRadius < minRadius)
			targetRadius = minRadius;
		transform.position = -targetRadius * transform.forward;

	}
}
