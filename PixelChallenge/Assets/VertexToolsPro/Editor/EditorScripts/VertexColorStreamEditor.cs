﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.SceneManagement;


[CustomEditor(typeof(VertexColorStream))]
public class VertexColorStreamEditor : Editor {

	private List<GameObject> linkedGameObjects;


	public override void OnInspectorGUI(){

		if (linkedGameObjects == null) {
			linkedGameObjects = new List<GameObject>();
			linkedGameObjects = checkForLinkGameObjects ();
		}

		DrawDefaultInspector();

		VertexColorStream vcs = (VertexColorStream)target;

		if (linkedGameObjects.Count > 0) {

			GUILayout.Space (15);
			if (GUILayout.Button ("Unlink this gameobject", GUILayout.Height (30))) {

				vcs.unlink ();
				EditorUtility.SetDirty (vcs.gameObject);
				EditorUtility.SetDirty (vcs);
				EditorUtility.SetDirty (vcs.gameObject.GetComponent<MeshFilter>() );
				EditorUtility.SetDirty (vcs.gameObject.GetComponent<MeshCollider>() );
				//EditorSceneManager.MarkSceneDirty (vcs.gameObject.scene);
				Undo.RegisterCompleteObjectUndo (vcs.gameObject, "Unlink gameobjects");

			}

		}
			
		if(!vcs.paintedMesh) {
			vcs.rebuild ();
			EditorUtility.SetDirty (vcs.gameObject);
			EditorUtility.SetDirty (vcs);
			EditorUtility.SetDirty (vcs.gameObject.GetComponent<MeshFilter>() );
			EditorUtility.SetDirty (vcs.gameObject.GetComponent<MeshCollider>() );
			//EditorSceneManager.MarkSceneDirty (vcs.gameObject.scene);
			Undo.RegisterCompleteObjectUndo (vcs.gameObject, "Rebuild Mesh");

		}
	}
		
	void OnSceneGUI() {

		if (linkedGameObjects == null) {
			linkedGameObjects = new List<GameObject>();
			linkedGameObjects = checkForLinkGameObjects ();
		}


		if (linkedGameObjects.Count == 0) {
			return;
		}



		VertexColorStream vcs = (VertexColorStream)target;
		float sceneWidth = SceneView.currentDrawingSceneView.position.width;
		float sceneHeight = SceneView.currentDrawingSceneView.position.height;

		Handles.BeginGUI ();
		GUILayout.BeginArea (new Rect (10, sceneHeight-70, sceneWidth-20, 40));

		GUILayout.BeginHorizontal ();

			if (GUILayout.Button ("This GameObject is linked to one or more other Gameobject. Click to unlink it now.", GUILayout.Height (40))) {
				vcs.unlink ();
				linkedGameObjects = checkForLinkGameObjects ();
				EditorUtility.SetDirty (vcs.gameObject);
				EditorUtility.SetDirty (vcs);
				EditorUtility.SetDirty (vcs.gameObject.GetComponent<MeshFilter>() );
				EditorUtility.SetDirty (vcs.gameObject.GetComponent<MeshCollider>() );
				//EditorSceneManager.MarkSceneDirty (vcs.gameObject.scene);
				Undo.RegisterCompleteObjectUndo (vcs.gameObject, "Unlink gameobjects");
			}

		GUILayout.EndHorizontal ();

		GUILayout.EndArea ();
		Handles.EndGUI ();

	}
		
	private List<GameObject> checkForLinkGameObjects() {


		VertexColorStream vcs = (VertexColorStream)target;
		GameObject[] gos = (GameObject[]) GameObject.FindObjectsOfType(typeof(GameObject));

		List<GameObject> tmp_linkedGameObjects = new List<GameObject> ();
		foreach (GameObject go in gos) {

			if (go == vcs.gameObject)
				continue;

			if (!go.GetComponent<VertexColorStream> ())
				continue;

			if (go.GetComponent<VertexColorStream> ().paintedMesh != vcs.paintedMesh)
				continue;

			tmp_linkedGameObjects.Add (go);

		}

		return tmp_linkedGameObjects;

	}


		
}