using System.Collections.Generic;

using UnityEngine;

using Broccoli.Model;

namespace Broccoli.Builder {
	public interface IBranchMeshBuilder {
		#region Vars
		void SetAngleTolerance (float angleTolerance);
		float GetAngleTolerance ();
		#endregion
		#region Methods
		/// <summary>
		/// Get the branch mesh builder type.
		/// </summary>
		/// <returns>Branch mesh builder type.</returns>
		BranchMeshBuilder.BuilderType GetBuilderType ();
		/// <summary>
		/// Called right after a BranchSkin is created.
		/// </summary>
		/// <param name="branchSkin">BranchSkin instance to process.</param>
		/// <param name="firstBranch">The first branch instance on the BranchSkin instance.</param>
		/// <returns>True if any processing gets done.</returns>
		bool PreprocessBranchSkin (BranchMeshBuilder.BranchSkin branchSkin, BroccoTree.Branch firstBranch);
		/// <summary>
		/// Gets the number of segments (like polygon sides) as resolution for a branch position.
		/// </summary>
		/// <param name="branchSkin">BranchSkin instance.</param>
		/// <param name="branchSkinPosition">Position along the BranchSkin instance.</param>
		/// <param name="branchAvgGirth">Branch average girth.</param>
		/// <returns>The number polygon sides.</returns>
		int GetNumberOfSegments (BranchMeshBuilder.BranchSkin branchSkin, float branchSkinPosition, float branchAvgGirth);
		Vector3[] GetPolygonAt (
			BranchMeshBuilder.BranchSkin branchSkin,
			int segmentIndex,
			ref List<float> radialPositions,
			float scale,
			float radiusScale = 1f);
		Vector3[] GetPolygonAt (
			int branchSkinId,
			Vector3 center, 
			Vector3 lookAt, 
			Vector3 normal, 
			float radius, 
			int polygonSides,
			ref List<float> radialPositions,
			float scale,
			float radiusScale = 1f);
		#endregion
	}
}