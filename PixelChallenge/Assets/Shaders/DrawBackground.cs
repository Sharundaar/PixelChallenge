using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBackground : MonoBehaviour {

	Material material;

	[SerializeField]
	Texture backgroundImage;

	void Awake () {
		material = new Material(Shader.Find("Hidden/BackgroundDraw"));
	}
	
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if (backgroundImage == null)
			return;

		material.SetTexture("_BackgroundTex", backgroundImage);
		Graphics.Blit(source, destination, material);
	}
}
