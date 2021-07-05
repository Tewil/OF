﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Broccoli.Serialization;

namespace Broccoli.Factory
{
	/// <summary>
	/// Tree factory preferences.
	/// </summary>
	[System.Serializable]
	public class TreeFactoryPreferences {
		#region Vars
		/// <summary>
		/// The scale applied to all the produced objects by the factory.
		/// </summary>
		public float factoryScale = 1.0f;
		/// <summary>
		/// Debug option to show sprout direction and normals.
		/// </summary>
		public bool debugShowDrawSprouts = true;
		/// <summary>
		/// Debug option to show branch structure.
		/// </summary>
		public bool debugShowDrawBranches = true;
		/// <summary>
		/// The canvas offset.
		/// </summary>
		public Vector2 canvasOffset = Vector3.zero;
		#endregion

		#region Preview Vars
		/// <summary>
		/// The preview mode to build trees.
		/// </summary>
		public TreeFactory.PreviewMode previewMode = TreeFactory.PreviewMode.Colored;
		#endregion

		#region Material Vars
		/// <summary>
		/// Enumeration for the available tree shaders to use.
		/// </summary>
		public enum PreferredShader {
			TreeCreator,
			SpeedTree7,
			SpeedTree8,
			TreeCreatorCompatible,
			SpeedTree7Compatible,
			SpeedTree8Compatible
		}
		/// <summary>
		/// Preferred tree shader to use.
		/// </summary>
		public PreferredShader preferredShader = PreferredShader.SpeedTree7;
		/// <summary>
		/// Custom shader to use on branches when a compatible shader option is selected.
		/// </summary>
		public Shader customBranchShader = null;
		/// <summary>
		/// Custom shader to use on sprouts when a compatible shader option is selected.
		/// </summary>
		public Shader customSproutShader = null;
		/// <summary>
		/// If true and cloning is enabled then the custom material is used as a base for 
		/// the preview and prefab material using a native shader (Unity's tree creator).
		/// </summary>
		public bool overrideMaterialShaderEnabled { get { return false; } }
		#endregion

		#region Prefab Vars
		/// <summary>
		/// If true a texture atlas is created on the prefab process.
		/// </summary>
		public bool prefabCreateAtlas = true;
		/// <summary>
		/// The size of the atlas texture.
		/// </summary>
		public TreeFactory.TextureSize atlasTextureSize = TreeFactory.TextureSize._512px;
		/// <summary>
		/// The size of the billboard texture.
		/// </summary>
		public TreeFactory.TextureSize billboardTextureSize = TreeFactory.TextureSize._512px;
		/// <summary>
		/// Number of side images to take on the billboard asset creation process.
		/// </summary>
		public int billboardImageCount = 8;
		/// <summary>
		/// If true the generated prefab has one level LOD for the mesh.
		/// </summary>
		public bool prefabStrictLowPoly = false;
		/// <summary>
		/// Use 2 LOD groups on the final prefab. This option is false if the prefab is on strict low-poly mode.
		/// </summary>
		public bool prefabUseLODGroups = true;
		/// <summary>
		/// LOD group includes a billboard asset.
		/// </summary>
		public bool prefabIncludeBillboard = true;
		/// <summary>
		/// If true the prefab mesh coordinates are adjusted to match vector zero position.
		/// </summary>
		public bool prefabRepositionEnabled = true;
		/// <summary>
		/// If true when using custom materials these are cloned inside the prefab.
		/// </summary>
		public bool prefabCloneCustomMaterialEnabled = true;
		/// <summary>
		/// If true the textures from a bark custom material are copied to the prefab folder.
		/// </summary>
		public bool prefabCopyCustomMaterialBarkTexturesEnabled = true;
		/// <summary>
		/// The appendable components.
		/// </summary>
		public List<ComponentReference> appendableComponents;
		#endregion

		#region Clone
		/// <summary>
		/// Clone this instance.
		/// </summary>
		public TreeFactoryPreferences Clone () {
			TreeFactoryPreferences clone = new TreeFactoryPreferences ();
			clone.factoryScale = factoryScale;
			clone.previewMode = previewMode;
			clone.prefabCreateAtlas = prefabCreateAtlas;
			clone.atlasTextureSize = atlasTextureSize;
			clone.billboardTextureSize = billboardTextureSize;
			clone.billboardImageCount = billboardImageCount;
			clone.prefabStrictLowPoly = prefabStrictLowPoly;
			clone.prefabUseLODGroups = prefabUseLODGroups;
			clone.prefabIncludeBillboard = prefabIncludeBillboard;
			clone.prefabRepositionEnabled = prefabRepositionEnabled;
			clone.prefabCloneCustomMaterialEnabled = prefabCloneCustomMaterialEnabled;
			clone.prefabCopyCustomMaterialBarkTexturesEnabled = prefabCopyCustomMaterialBarkTexturesEnabled;
			clone.appendableComponents = new List<ComponentReference> (appendableComponents);
			clone.debugShowDrawSprouts = debugShowDrawSprouts;
			clone.debugShowDrawBranches = debugShowDrawBranches;
			clone.canvasOffset = canvasOffset;
			clone.preferredShader = preferredShader;
			clone.customSproutShader = customSproutShader;
			clone.customBranchShader = customBranchShader;
			return clone;
		}
		#endregion
	}
}