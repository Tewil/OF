using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Broccoli.Base;
using Broccoli.NodeEditorFramework;
using Broccoli.NodeEditorFramework.Utilities;

namespace Broccoli.NodeEditorFramework 
{
	public static partial class NodeEditorGUI 
	{
		internal static string curEditorUser;
		internal static bool isEditorWindow;

		// static GUI settings, textures and styles
		public static int knobSize = 16;

		public static Color NE_LightColor = new Color (0.4f, 0.4f, 0.4f);
		public static Color NE_TextColor = new Color (0.7f, 0.7f, 0.7f);

		public static Texture2D Background;
		public static Texture2D AALineTex;
		public static Texture2D GUIBox;
		public static Texture2D GUIButton;
		public static Texture2D GUIBoxSelection;

		public static GUISkin defaultSkin;
		public static GUISkin nodeSkin;
		public static GUISkin sidePanelSkin;
		public static Stack<GUISkin> skinStack = new Stack<GUISkin> ();

		public static GUIStyle nodeLabel;
		public static GUIStyle nodeLabelBold;
		public static GUIStyle nodeLabelSelected;
		public static GUIStyle nodeLabelCentered;
		public static GUIStyle nodeLabelBoldCentered;

		public static GUIStyle nodeBox;
		public static GUIStyle nodeBoxBold;
		
		public static bool Init ()
		{
			// Textures
			Background = ResourceManager.LoadTexture ("Broccoli/GUI/background_b.png");
			AALineTex = ResourceManager.LoadTexture ("Broccoli/GUI/AALine.png");
			GUIBox = ResourceManager.LoadTexture ("Broccoli/GUI/NE_Box.png");
			GUIButton = ResourceManager.LoadTexture ("Broccoli/GUI/NE_Button.png");
			GUIBoxSelection = ResourceManager.LoadTexture ("Broccoli/GUI/BoxSelection.png");

			if (!Background || !AALineTex || !GUIBox || !GUIButton)
				return false;
			
			// Skin & Styles
			defaultSkin = UnityEngine.Object.Instantiate (GUI.skin);
			//defaultSkin = ResourceManager.LoadResource<GUISkin>("DefaultGUISkin.guiskin");

			// Node Skin
			nodeSkin = ResourceManager.LoadResource<GUISkin>("Broccoli/GUI/NodeGUISkin.guiskin");

			// Side Panel Skin
			sidePanelSkin = ResourceManager.LoadResource<GUISkin>("Broccoli/GUI/SidePanelGUISkin.guiskin");

			// Label
			nodeLabel = nodeSkin.label;
			// Box
			nodeSkin.box.normal.textColor = NE_TextColor;
			nodeBox = nodeSkin.box;
			// Button
			nodeSkin.button.normal.textColor = NE_TextColor;
			nodeSkin.button.fixedHeight = 25;
			// TextArea
			nodeSkin.textArea.normal.background = GUIBox;
			nodeSkin.textArea.active.background = GUIBox;
			// Bold Label
			nodeLabelBold = new GUIStyle (nodeLabel);
			nodeLabelBold.fontStyle = FontStyle.Bold;
			// Selected Label
			nodeLabelSelected = new GUIStyle (nodeLabel);
			nodeLabelSelected.normal.background = RTEditorGUI.ColorToTex (1, NE_LightColor);
			// Centered Label
			nodeLabelCentered = new GUIStyle (nodeLabel);
			nodeLabelCentered.alignment = TextAnchor.MiddleCenter;
			// Centered Bold Label
			nodeLabelBoldCentered = new GUIStyle (nodeLabelBold);
			nodeLabelBoldCentered.alignment = TextAnchor.MiddleCenter;
			// Bold Box
			nodeBoxBold = new GUIStyle (nodeBox);
			nodeBoxBold.fontStyle = FontStyle.Bold;

			//SetCustomStyles ();

			return true;
		}

		public static void SetCustomStyles () {
			GUIStyle styleRLBackground = new GUIStyle (sidePanelSkin.box);
			styleRLBackground.name = "BRL Background";
			GUIStyle styleRLFooterButton = new GUIStyle (sidePanelSkin.button);
			styleRLFooterButton.fixedWidth = 25f;
			styleRLFooterButton.name = "BRL FooterButton";


			GUIStyle[] customStyles = new GUIStyle[2];
			customStyles [0] = styleRLBackground;
			customStyles [1] = styleRLFooterButton;
			sidePanelSkin.customStyles = customStyles;
			/*
			 * public readonly GUIStyle draggingHandle = "RL DragHandle";
				public readonly GUIStyle headerBackground = "RL Header";
				public readonly GUIStyle footerBackground = "RL Footer";
				public readonly GUIStyle boxBackground = "RL Background";
				public readonly GUIStyle preButton = "RL FooterButton";
				RL Element
			 */
		}

		#region Skins
		/// <summary>
		/// Begins using default skin for the GUI.
		/// </summary>
		public static void BeginUsingDefaultSkin () {
			BeginUsingSkin (defaultSkin);
		}
		/// <summary>
		/// Begins using the node canvas skin for the GUI.
		/// </summary>
		public static void BeginUsingNodeSkin () {
			BeginUsingSkin (nodeSkin);
		}
		/// <summary>
		/// Begins using the side panel skin for the GUI.
		/// </summary>
		public static void BeginUsingSidePanelSkin () {
			BeginUsingSkin (sidePanelSkin);
		}
		/// <summary>
		/// Begins using a skin for the GUI.
		/// </summary>
		/// <param name="skin">Skin.</param>
		public static void BeginUsingSkin (GUISkin skin) {
			skinStack.Push (skin);
			GUI.skin = skinStack.Peek ();
		}
		/// <summary>
		/// Ends usage of the assigned skin for the GUI.
		/// </summary>
		public static void EndUsingSkin () {
			skinStack.Pop ();
			if (skinStack.Count == 0) {
				GUI.skin = defaultSkin;
			} else {
				GUI.skin = skinStack.Peek ();
			}
		}
		/// <summary>
		/// Determines if is using side panel skin.
		/// </summary>
		/// <returns><c>true</c> if is using side panel skin; otherwise, <c>false</c>.</returns>
		public static bool IsUsingSidePanelSkin () {
			return GUI.skin == sidePanelSkin;
		}
		#endregion

		public static void StartNodeGUI (string editorUser, bool IsEditorWindow) 
		{
			NodeEditor.checkInit(true);
			curEditorUser = editorUser;
			isEditorWindow = IsEditorWindow;
			BeginUsingNodeSkin ();
			OverlayGUI.StartOverlayGUI (curEditorUser);
		}

		public static void EndNodeGUI () 
		{
			OverlayGUI.EndOverlayGUI ();
			EndUsingSkin ();
		}

		#region Connection Drawing

		// Curve parameters
		public static float curveBaseDirection = 1.5f, curveBaseStart = 2f, curveDirectionScale = 0.004f;

		/// <summary>
		/// Draws a node connection from start to end, horizontally
		/// </summary>
		public static void DrawConnection (Vector2 startPos, Vector2 endPos, Color col, int lineWidth) 
		{
			Vector2 startVector = startPos.x <= endPos.x? Vector2.right : Vector2.left;
			DrawConnection (startPos, startVector, endPos, -startVector, col, lineWidth);
		}
		/// <summary>
		/// Draws a node connection from start to end with specified vectors
		/// </summary>
		public static void DrawConnection (Vector2 startPos, Vector2 startDir, Vector2 endPos, Vector2 endDir, Color col, int lineWidth) 
		{
			#if NODE_EDITOR_LINE_CONNECTION
			DrawConnection (startPos, startDir, endPos, endDir, ConnectionDrawMethod.StraightLine, col);
			#else
			DrawConnection (startPos, startDir, endPos, endDir, ConnectionDrawMethod.Bezier, col, lineWidth);
			#endif
		}
		/// <summary>
		/// Draws a node connection from start to end with specified vectors
		/// </summary>
		public static void DrawConnection (Vector2 startPos, Vector2 startDir, Vector2 endPos, Vector2 endDir, ConnectionDrawMethod drawMethod, Color col, int lineWidth) 
		{
			if (drawMethod == ConnectionDrawMethod.Bezier) 
			{
				float dirFactor = 50;//Mathf.Pow ((startPos-endPos).magnitude, 0.3f) * 20;
				RTEditorGUI.DrawBezier (startPos, endPos, startPos + startDir * dirFactor, endPos + endDir * dirFactor, col, null, lineWidth);
			}
			else if (drawMethod == ConnectionDrawMethod.StraightLine)
				RTEditorGUI.DrawLine (startPos, endPos, col, null, lineWidth);
		}

		/// <summary>
		/// Optimises the bezier directions scale so that the bezier looks good in the specified position relation.
		/// Only the magnitude of the directions are changed, not their direction!
		/// </summary>
		public static void OptimiseBezierDirections (Vector2 startPos, ref Vector2 startDir, Vector2 endPos, ref Vector2 endDir) 
		{
			Vector2 offset = (endPos - startPos) * curveDirectionScale;
			float baseDir = Mathf.Min (offset.magnitude/curveBaseStart, 1) * curveBaseDirection;
			Vector2 scale = new Vector2 (Mathf.Abs (offset.x) + baseDir, Mathf.Abs (offset.y) + baseDir);
			// offset.x and offset.y linearly increase at scale of curveDirectionScale
			// For 0 < offset.magnitude < curveBaseStart, baseDir linearly increases from 0 to curveBaseDirection. For offset.magnitude > curveBaseStart, baseDir = curveBaseDirection
			startDir = Vector2.Scale(startDir.normalized, scale);
			endDir = Vector2.Scale(endDir.normalized, scale);
		}

		/// <summary>
		/// Gets the second connection vector that matches best, accounting for positions
		/// </summary>
		internal static Vector2 GetSecondConnectionVector (Vector2 startPos, Vector2 endPos, Vector2 firstVector) 
		{
			if (firstVector.x != 0 && firstVector.y == 0)
				return startPos.x <= endPos.x? -firstVector : firstVector;
			else if (firstVector.y != 0 && firstVector.x == 0)
				return startPos.y <= endPos.y? -firstVector : firstVector;
			else
				return -firstVector;
		}

		#endregion
	}
}