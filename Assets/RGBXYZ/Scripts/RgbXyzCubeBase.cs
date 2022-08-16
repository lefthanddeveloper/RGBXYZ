using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGBXYZ
{
	public class RgbXyzCubeBase : MonoBehaviour
	{
		[Header("[ Cube Base Setting ]")]
		[SerializeField] private float distance = 0.5f;
		[SerializeField] private int numOnSide = 10;
		public float Distance => distance;
		public int NumOnSide => numOnSide;

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(this.transform.position, Vector3.one * numOnSide * distance);
		}
	}

}

