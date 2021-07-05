using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Broccoli.Pipe;
using Broccoli.Utils;
using Broccoli.NodeEditorFramework;

using Broccoli.NodeEditorFramework.Utilities;

namespace Broccoli.TreeNodeEditor
{
	/// <summary>
	/// SproutLab instance.
	/// </summary>
	public class SproutLabEditor {
		#region Vars
		/// <summary>
		/// Version of the SproutLabEditor.
		/// </summary>
		private static string version = "v0.1a";
		/// <summary>
		/// Mesh preview utility.
		/// </summary>
		MeshPreview meshPreview;
		#endregion

		#region GUI Vars
		/// <summary>
		/// Tab titles for panel sections.
		/// </summary>
		private static GUIContent[] panelSections = new GUIContent[4];
		/// <summary>
		/// Panel section selected.
		/// </summary>
		int currentPanelSection = 0;
		#endregion

		#region Constructor and Initialization
		/// <summary>
		/// Creates a new SproutLabEditor instance.
		/// </summary>
		public SproutLabEditor () {
			panelSections [0] = 
				new GUIContent ("Templates", "Select for a collection of predefined settings.");
			panelSections [1] = 
				new GUIContent ("Structure", "Settings for tunning the structure of the sprout.");
			panelSections [2] = 
				new GUIContent ("Branch", "Settings for tunning the branches on the sprout.");
			panelSections [3] = 
				new GUIContent ("Leaf", "Settings for tunning the leaves on the sprout.");
			OnEnable ();
		}
		public void OnEnable () {
			// Init mesh preview
			if (meshPreview == null) {
				meshPreview = new MeshPreview ();
				meshPreview.showPivot = true;
				meshPreview.onDrawHandles += OnPreviewMeshDrawHandles;
				meshPreview.onDrawGUI += OnPreviewMeshDrawGUI;
				/*
				pivotLabelStyle.normal.textColor = Color.yellow;
				gravityVectorLabelStyle.normal.textColor = Color.green;
				if (sproutMeshGeneratorNode.sproutMeshGeneratorElement.selectedMeshIndex > -1) {
					ShowPreviewMesh (sproutMeshGeneratorNode.sproutMeshGeneratorElement.selectedMeshIndex);
				}
				*/
			} else {
				meshPreview.Clear ();
			}
			//meshPreview.CreateViewport ();
			ShowPreviewMesh (0);
		}
		public void OnDisable () {
			if (meshPreview != null) {
				meshPreview.Clear ();
			}
		}
		/// <summary>
		/// Event called when destroying this editor.
		/// </summary>
		private void OnDestroy() {
			meshPreview.Clear ();
			if (meshPreview.onDrawHandles != null) {
				meshPreview.onDrawHandles -= OnPreviewMeshDrawHandles;
				meshPreview.onDrawGUI -= OnPreviewMeshDrawGUI;
			}
		}
		#endregion

		#region Draw Methods
        public void Draw (Rect windowRect) {
			GUI.DrawTextureWithTexCoords (windowRect, NodeEditorGUI.Background, Rect.zero);
			EditorGUILayout.BeginHorizontal ();
			GUILayout.Box ("", GUIStyle.none, 
				GUILayout.Width (150), 
				GUILayout.Height (60));
			GUI.DrawTexture (new Rect (5, 8, 140, 48), GUITextureManager.GetLogo (), ScaleMode.ScaleToFit);
			string catalogMsg = "Broccoli Tree Creator Sprout Lab " + version;
			EditorGUILayout.HelpBox (catalogMsg, MessageType.None);
			EditorGUILayout.EndHorizontal ();
			if (GUILayout.Button (new GUIContent ("Close Sprout Lab"))) {
				TreeFactoryEditorWindow.editorWindow.editorView = TreeFactoryEditorWindow.EditorView.MainOptions;
			}
			EditorGUILayout.Space ();
			DrawView (windowRect);
			EditorGUILayout.Space ();
			DrawStructurePanel ();
        }
		public void DrawView (Rect windowRect) {
			/*
			GUILayout.Box ("", GUIStyle.none, 
				GUILayout.Width (Screen.width), 
				GUILayout.Height (Screen.width));
				*/
			GUILayout.Box ("", GUIStyle.none, 
				GUILayout.Width (windowRect.width), 
				GUILayout.Height (windowRect.width));
			Rect viewRect = GUILayoutUtility.GetLastRect ();
			meshPreview.RenderViewport (viewRect, GUIStyle.none);
		}
		public void DrawStructurePanel () {
			currentPanelSection = GUILayout.Toolbar (currentPanelSection, panelSections, GUI.skin.button);
			switch (currentPanelSection) {
				case 0:
					EditorGUILayout.LabelField ("Template setting");
					break;
				case 1:
					EditorGUILayout.LabelField ("Structure setting");
					break;
				case 2:
					EditorGUILayout.LabelField ("Branch setting");
					break;
				case 3:
					EditorGUILayout.LabelField ("Leaf setting");
					break;
			}
		}
		#endregion

		#region Mesh Preview
		/// <summary>
		/// Get a preview mesh for a SproutMesh.
		/// </summary>
		/// <returns>Mesh for previewing.</returns>
		public Mesh GetPreviewMesh (SproutMesh sproutMesh, SproutMap.SproutMapArea sproutMapArea) {
			/*
			SproutMeshBuilder.GetInstance ().globalScale = 1f;
			bool isTwoSided = TreeFactory.GetActiveInstance ().materialManager.IsSproutTwoSided ();
			return SproutMeshBuilder.GetPreview (sproutMesh, isTwoSided, sproutMapArea);
			*/
			return GameObject.CreatePrimitive (PrimitiveType.Cube).GetComponent<MeshFilter> ().sharedMesh;
		}
		/// <summary>
		/// Show a preview mesh.
		/// </summary>
		/// <param name="index">Index.</param>
		public void ShowPreviewMesh (int index) {
			Mesh mesh = GetPreviewMesh (null, null);
			Material material = new Material(Shader.Find ("Standard"));
			/*
			if (!previewMeshes.ContainsKey (index) || previewMeshes [index] == null) {
				SproutMesh sproutMesh = sproutMeshGeneratorNode.sproutMeshGeneratorElement.sproutMeshes [index];
				SproutMap sproutMap = GetSproutMap (sproutMesh.groupId);
				SproutMap.SproutMapArea sproutMapArea = sproutMap.GetMapArea ();
				mesh = GetPreviewMesh (sproutMesh, sproutMapArea);
				if (sproutMap != null) {
					material = MaterialManager.GetPreviewLeavesMaterial (sproutMap, sproutMapArea);
					previewMaterials.Add (index, material);
				}
				previewMeshes.Add (index, mesh);
			} else {
				mesh = previewMeshes [index];
				if (previewMaterials.ContainsKey (index)) {
					material = previewMaterials [index];
				}
			}*/
			meshPreview.Clear ();
			meshPreview.CreateViewport ();
			mesh.RecalculateBounds();
			if (material != null) {
				meshPreview.AddMesh (0, mesh, material, true);
			} else {
				meshPreview.AddMesh (0, mesh, true);
			}
			/*
			if (!autoZoomUsed) {
				autoZoomUsed = true;
				meshPreview.CalculateZoom (mesh);
			}
			*/
		}
		/// <summary>
		/// Draw additional handles on the mesh preview area.
		/// </summary>
		/// <param name="r">Rect</param>
		/// <param name="camera">Camera</param>
		public void OnPreviewMeshDrawHandles (Rect r, Camera camera) {
			Handles.color = Color.green;
			Handles.ArrowHandleCap (0,
				Vector3.zero, 
				Quaternion.LookRotation (Vector3.down), 
				1f * MeshPreview.GetHandleSize (Vector3.zero, camera), 
				EventType.Repaint);
		}
		/// <summary>
		/// Draws GUI elements on the mesh preview area.
		/// </summary>
		/// <param name="r">Rect</param>
		/// <param name="camera">Camera</param>
		public void OnPreviewMeshDrawGUI (Rect r, Camera camera) {
			/*
			r.y += EditorGUIUtility.singleLineHeight;
			GUI.Label (r, "[Pivot]", pivotLabelStyle);
			r.y += EditorGUIUtility.singleLineHeight;
			GUI.Label (r, "[Gravity]", gravityVectorLabelStyle);
			*/
		}
		#endregion
	}
}