using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Object = UnityEngine.Object;

namespace Broccoli.Base
{
	/// <summary>
	/// Extension manager.
	/// </summary>
	public static class ExtensionManager
	{
		#region Vars
		/// <summary>
		/// Init flag, true when the extension is initialized.
		/// </summary>
		private static bool isInit = false;
		/// <summary>
		/// Path used by the extension.
		/// </summary>
		private static string _extensionPath = "";
		/// <summary>
		/// Gets the extension path.
		/// </summary>
		/// <value>The extension path.</value>
		public static string extensionPath { 
			get {
				if (!isInit) {
					Init ();
				}
				return _extensionPath; 
			} 
		}
		/// <summary>
		/// Gets the full extension path.
		/// </summary>
		/// <value>The full extension path.</value>
		public static string fullExtensionPath {
			get {
				return Application.dataPath + 
					ExtensionManager.extensionPath.Replace ("Assets", "");
			}
		}
		/// <summary>
		/// The resources path.
		/// </summary>
		private static string _resourcesPath = "";
		/// <summary>
		/// The resources path.
		/// </summary>
		public static string resourcesPath {
			get {
				if (!isInit) {
					Init ();
				}
				return _resourcesPath;
			}
		}
		#if UNITY_EDITOR
		/// <summary>
		/// Asset name used as reference to find the extension path.
		/// </summary>
		private static string uniqueExtensionAsset = "BroccoliExtensionInfo";
		#endif
		#endregion

		#region Initialization
		/// <summary>
		/// Init this class.
		/// </summary>
		public static void Init () {
			if (!isInit) {
				SetupBase ();
			}
		}
		/// <summary>
		/// Setups the base of the extension.
		/// </summary>
		public static void SetupBase () {
			if (CheckExtensionPath () && 
				SetPaths ()) {
				isInit = true;
			}
		}
		/// <summary>
		/// Checks the extension path.
		/// </summary>
		/// <returns><c>true</c>, if extension path was checked, <c>false</c> otherwise.</returns>
		private static bool CheckExtensionPath () {
			#if UNITY_EDITOR
			Object script = 
				UnityEditor.AssetDatabase.LoadAssetAtPath (_extensionPath + "Base/" + 
					uniqueExtensionAsset + ".cs", typeof(Object));
			if (script == null) {
				string[] assets = UnityEditor.AssetDatabase.FindAssets (uniqueExtensionAsset);
				if (assets.Length > 0) {
					_extensionPath = UnityEditor.AssetDatabase.GUIDToAssetPath (assets [0]);
					int subFolderIndex = _extensionPath.LastIndexOf ("Base/");
					if (subFolderIndex == -1)
						throw new UnityException ("Broccoli Tree Creator: Correct path could not be detected! " +
							"Please correct the _extensionPath variable in ExtensionManager.cs!");
					_extensionPath = _extensionPath.Substring (0, subFolderIndex);
					_resourcesPath = _extensionPath + "Resources/";
					return true;
				} else {
					throw new UnityException ("Broccoli Tree Creator: Correct path could not be detected! " +
						"Please correct the _extensionPath variable in ExtensionManager.cs!");
				}
			}
			return false;
			#else
			return true;
			#endif
		}
		/// <summary>
		/// Sets the paths for the extension.
		/// </summary>
		/// <returns><c>true</c>, if paths was set, <c>false</c> otherwise.</returns>
		private static bool SetPaths () {
			return true;
		}
		#endregion
	}
}