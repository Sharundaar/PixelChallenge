using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDrawOrder : MonoBehaviour {

	PlayerData[] players;
	Camera cam;

	bool p1InFrontP2;

	int layerIdx1, layerIdx2;

	// Use this for initialization
	void Start () {
		players = FindObjectsOfType<PlayerData>();
		cam = FindObjectOfType<Camera>();

		layerIdx1 = SortingLayer.NameToID("Pirate1");
		layerIdx2 = SortingLayer.NameToID("Pirate2");
	}
	
	// Update is called once per frame
	void Update () {
		float distCamP1 = Vector3.Distance(cam.transform.position, players[0].transform.position);
		float distCamP2 = Vector3.Distance(cam.transform.position, players[1].transform.position);

		if((distCamP1 < distCamP2) && !p1InFrontP2)
		{
			var renderers = players[0].GetComponentsInChildren<SpriteRenderer>();
			for(int i=0; i<renderers.Length; ++i)
			{
				renderers[i].sortingLayerID = layerIdx2;
			}

			renderers = players[1].GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < renderers.Length; ++i)
			{
				renderers[i].sortingLayerID = layerIdx1;
			}
			p1InFrontP2 = true;
		}
		else if((distCamP1 > distCamP2) && p1InFrontP2 )
		{
			var renderers = players[1].GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < renderers.Length; ++i)
			{
				renderers[i].sortingLayerID = layerIdx2;
			}

			renderers = players[0].GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < renderers.Length; ++i)
			{
				renderers[i].sortingLayerID = layerIdx1;
			}
			p1InFrontP2 = false;
		}
	}
}
