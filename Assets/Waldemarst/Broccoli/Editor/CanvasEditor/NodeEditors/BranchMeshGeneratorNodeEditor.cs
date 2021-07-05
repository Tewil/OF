using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

using Broccoli.Base;

namespace Broccoli.TreeNodeEditor
{
	/// <summary>
	/// Branch mesh generator node editor.
	/// </summary>
	[CustomEditor(typeof(BranchMeshGeneratorNode))]
	public class BranchMeshGeneratorNodeEditor : BaseNodeEditor {
		#region Vars
		/// <summary>
		/// The branch mesh generator node.
		/// </summary>
		public BranchMeshGeneratorNode branchMeshGeneratorNode;

		SerializedProperty propMinPolygonSides;
		SerializedProperty propMaxPolygonSides;
		SerializedProperty propSegmentAngle;
		SerializedProperty propUseHardNormals;
		SerializedProperty propUseAverageNormals;
		SerializedProperty propMinBranchCurveResolution;
		SerializedProperty propMaxBranchCurveResolution;
		#endregion

		#region Messages
		private static string MSG_MIN_POLYGON_SIDES = "Minimum number of sides on the polygon used to create the mesh.";
		private static string MSG_MAX_POLYGON_SIDES = "Maximum number of sides on the polygon used to create the mesh.";
		private static string MSG_SEGMENT_MESH_ANGLE = "Rotation angle of the polygon around the branch center.";
		private static string MSG_MIN_BRANCH_CURVE_RESOLUTION = "Minimum resolution used to process branch curves to create segments. " +
			"The minimum value is used when processing the mesh to ge used at the lowest resolution LOD.";
		private static string MSG_MAX_BRANCH_CURVE_RESOLUTION = "Maximum resolution used to process branch curves to create segments. " +
			"The maximum value is used when processing the mesh to be used at the highest resolution LOD.";
		private static string MSG_USE_HARD_NORMALS = "Hard normals increases the number vertices per face while " +
			"keeping the same number of triangles. This option is useful to give a lowpoly flat shaded effect on the mesh.";
		private static string MSG_USE_AVERAGE_NORMALS = "The base of children branches average their normals to their parent, " +
			"this gives a smoother light transition between a parent branch and its children.";
		#endregion

		#region Events
		/// <summary>
		/// Actions to perform on the concrete class when the enable event is raised.
		/// </summary>
		protected override void OnEnableSpecific () {
			branchMeshGeneratorNode = target as BranchMeshGeneratorNode;

			SetPipelineElementProperty ("branchMeshGeneratorElement");
			propMinPolygonSides = GetSerializedProperty ("minPolygonSides");
			propMaxPolygonSides = GetSerializedProperty ("maxPolygonSides");
			propSegmentAngle = GetSerializedProperty ("segmentAngle");
			propUseHardNormals = GetSerializedProperty ("useHardNormals");
			propUseAverageNormals = GetSerializedProperty ("useAverageNormals");
			propMinBranchCurveResolution = GetSerializedProperty ("minBranchCurveResolution");
			propMaxBranchCurveResolution = GetSerializedProperty ("maxBranchCurveResolution");
		}
		/// <summary>
		/// Raises the inspector GUI event.
		/// </summary>
		public override void OnInspectorGUI() {
			CheckUndoRequest ();

			UpdateSerialized ();

			EditorGUI.BeginChangeCheck ();

			int maxPolygonSides = propMaxPolygonSides.intValue;
			EditorGUILayout.IntSlider (propMaxPolygonSides, 3, 16, "Max Polygon Sides");
			ShowHelpBox (MSG_MAX_POLYGON_SIDES);
			EditorGUILayout.Space ();

			int minPolygonSides = propMinPolygonSides.intValue;
			EditorGUILayout.IntSlider (propMinPolygonSides, 3, 16, "Min Polygon Sides");
			ShowHelpBox (MSG_MIN_POLYGON_SIDES);
			EditorGUILayout.Space ();

			float segmentAngle = propSegmentAngle.floatValue;
			EditorGUILayout.Slider (propSegmentAngle, 0f, 180f, "Segment Mesh Angle");
			ShowHelpBox (MSG_SEGMENT_MESH_ANGLE);
			EditorGUILayout.Space ();

			float maxBranchCurveResolution = propMaxBranchCurveResolution.floatValue;
			EditorGUILayout.Slider (propMaxBranchCurveResolution, 0, 1, "Max Branch Curve Resolution");
			ShowHelpBox (MSG_MAX_BRANCH_CURVE_RESOLUTION);
			EditorGUILayout.Space ();

			float minBranchCurveResolution = propMinBranchCurveResolution.floatValue;
			EditorGUILayout.Slider (propMinBranchCurveResolution, 0, 1, "Min Branch Curve Resolution");
			ShowHelpBox (MSG_MIN_BRANCH_CURVE_RESOLUTION);
			EditorGUILayout.Space ();

			bool useHardNormals = propUseHardNormals.boolValue;
			EditorGUILayout.PropertyField (propUseHardNormals);
			ShowHelpBox (MSG_USE_HARD_NORMALS);
			EditorGUILayout.Space ();

			bool useAverageNormals = propUseAverageNormals.boolValue;
			if (!useHardNormals) {
				useAverageNormals = EditorGUILayout.PropertyField (propUseAverageNormals);
				ShowHelpBox (MSG_USE_AVERAGE_NORMALS);
				EditorGUILayout.Space ();
			}			

			if (EditorGUI.EndChangeCheck () &&
				propMinPolygonSides.intValue <= propMaxPolygonSides.intValue &&
				propMinBranchCurveResolution.floatValue <= propMaxBranchCurveResolution.floatValue) {
				ApplySerialized ();
				if (minPolygonSides != propMinPolygonSides.intValue ||
					maxPolygonSides != propMaxPolygonSides.intValue ||
					minBranchCurveResolution != propMinBranchCurveResolution.floatValue ||
					maxBranchCurveResolution != propMaxBranchCurveResolution.floatValue ||
					segmentAngle != propSegmentAngle.floatValue ||
					useHardNormals != propUseHardNormals.boolValue ||
					useAverageNormals != propUseAverageNormals.boolValue) {
					UpdatePipeline (GlobalSettings.processingDelayHigh);
					NodeEditorFramework.NodeEditor.RepaintClients ();
					branchMeshGeneratorNode.branchMeshGeneratorElement.Validate ();
					SetUndoControlCounter ();
				}
			}
			if (branchMeshGeneratorNode.branchMeshGeneratorElement.showLODInfoLevel == 1) {
			} else if (branchMeshGeneratorNode.branchMeshGeneratorElement.showLODInfoLevel == 2) {
			} else {
				EditorGUILayout.HelpBox ("LOD0\nVertex Count: " + branchMeshGeneratorNode.branchMeshGeneratorElement.verticesCountSecondPass +
					"\nTriangle Count: " + branchMeshGeneratorNode.branchMeshGeneratorElement.trianglesCountSecondPass + "\nLOD1\nVertex Count: " + branchMeshGeneratorNode.branchMeshGeneratorElement.verticesCountFirstPass +
				"\nTriangle Count: " + branchMeshGeneratorNode.branchMeshGeneratorElement.trianglesCountFirstPass, MessageType.Info);
			}
			EditorGUILayout.Space ();
	
			// Field descriptors option.
			DrawFieldHelpOptions ();
		}
		#endregion
	}
}