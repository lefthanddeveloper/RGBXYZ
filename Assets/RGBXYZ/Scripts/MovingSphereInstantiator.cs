using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGBXYZ
{
    public class MovingSphereInstantiator : MonoBehaviour
    {
		[SerializeField] private MeshRenderer meshRend;
		[SerializeField] private Color defaultColor = Color.white;
		[SerializeField] private Color highlightColor = Color.white;

		public Action<MovingSphereInstantiator> onClick;

		private void OnMouseEnter()
		{
			meshRend.material.color = highlightColor;
		}

		private void OnMouseExit()
		{
			meshRend.material.color = defaultColor;
		}

		private void OnMouseDown()
		{
			onClick?.Invoke(this);
		}
	}

}