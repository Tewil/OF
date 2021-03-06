using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Broccoli.Model;

namespace Broccoli.Builder {
	/// <summary>
	/// Gives methods to help create mesh segments using BranchSkin instances.
	/// 
	/// </summary>
	public class DefaultMeshBuilder : IBranchMeshBuilder {
		#region Vars
		
		#endregion

		#region Interface
		public virtual void SetAngleTolerance (float angleTolerance) {}
		public virtual float GetAngleTolerance () { return 15f; }
		/// <summary>
		/// Get the branch mesh builder type.
		/// </summary>
		/// <returns>Branch mesh builder type.</returns>
		public virtual BranchMeshBuilder.BuilderType GetBuilderType () {
			return BranchMeshBuilder.BuilderType.Default;
		}
		/// <summary>
		/// Called right after a BranchSkin is created.
		/// </summary>
		/// <param name="branchSkin">BranchSkin instance to process.</param>
		/// <param name="firstBranch">The first branch instance on the BranchSkin instance.</param>
		/// <returns>True if any processing gets done.</returns>
		public virtual bool PreprocessBranchSkin (BranchMeshBuilder.BranchSkin branchSkin, BroccoTree.Branch firstBranch) {
			return false;
		}
		#endregion

		#region Vertices
		public virtual Vector3[] GetPolygonAt (
			BranchMeshBuilder.BranchSkin branchSkin,
			int segmentIndex,
			ref List<float> radialPositions,
			float scale,
			float radiusScale = 1f)
		{
			return GetPolygonAt (branchSkin.id, branchSkin.centers [segmentIndex], branchSkin.directions [segmentIndex], branchSkin.normals [segmentIndex],
				branchSkin.girths [segmentIndex], branchSkin.segments [segmentIndex], ref radialPositions, scale, radiusScale);
		}
		/// <summary>
		/// Get an array of vertices around a center point with some rotation.
		/// </summary>
		/// <returns>Vertices for the polygon <see cref="System.Collections.Generic.List`1[[UnityEngine.Vector3]]"/> points.</returns>
		/// <param name="center">Center of the polygon.</param>
		/// <param name="lookAt">Look at rotation.</param>
		/// <param name="radius">Radius of the polygon.</param>
		/// <param name="polygonSides">Number of sides for the polygon.</param>
		public virtual Vector3[] GetPolygonAt (
			int branchSkinId,
			Vector3 center, 
			Vector3 lookAt, 
			Vector3 normal, 
			float radius, 
			int polygonSides,
			ref List<float> radialPositions,
			float scale,
			float radiusScale = 1f)
		{
			center *= scale;
			radius *= scale * radiusScale;
			//Debug.Log ("        radius " + radius);
			Vector3[] polygonVertices = new Vector3 [polygonSides];

			if (polygonSides >= 3) {
				float angle = (Mathf.PI * 2) / (float)polygonSides;
				float radialAngle = 1f / (float)polygonSides;
				for (int i = 0; i < polygonSides; i++) {
					Vector3 point = new Vector3 (
						Mathf.Cos (angle * i) * radius,
						Mathf.Sin (angle * i) * radius,
						0f);
					Quaternion rotation = Quaternion.LookRotation (lookAt, normal);
					point = rotation * point;
					polygonVertices [i] = point + center;
					radialPositions.Add (i * radialAngle);
				}
			} else {
				Debug.LogError ("Polygon sides is expected to be equal or greater than 3.");
			}
			return polygonVertices;
		}
		/// <summary>
		/// Gets the number of segments (like polygon sides) as resolution for a branch position.
		/// </summary>
		/// <param name="branchSkin">BranchSkin instance.</param>
		/// <param name="branchSkinPosition">Position along the BranchSkin instance.</param>
		/// <param name="branchAvgGirth">Branch average girth.</param>
		/// <returns>The number polygon sides.</returns>
		public virtual int GetNumberOfSegments (BranchMeshBuilder.BranchSkin branchSkin, float branchSkinPosition, float branchAvgGirth) {
			float girthPosition = (branchAvgGirth - branchSkin.minAvgGirth) / (branchSkin.maxAvgGirth - branchSkin.minAvgGirth);
			branchSkin.polygonSides = Mathf.Clamp (
				Mathf.RoundToInt (
					Mathf.Lerp (
						branchSkin.minPolygonSides,
						branchSkin.maxPolygonSides,
						girthPosition)), 
						branchSkin.minPolygonSides,
						branchSkin.maxPolygonSides);
			return branchSkin.polygonSides;
		}
		#endregion
	}
}