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
		[SerializeField] private Color occupiedColor = Color.white;


		public Action<MovingSphereInstantiator> onClick;

		private MovingSphere movingSphere = null;
		public bool IsOccupied => movingSphere != null;

		private void OnMouseEnter()
		{
            if (IsOccupied)
            {
				meshRend.material.color = occupiedColor;
            }
            else
            {
				meshRend.material.color = highlightColor;
            }

		}

		private void OnMouseExit()
		{
			meshRend.material.color = defaultColor;
		}

		private void OnMouseDown()
		{
			onClick?.Invoke(this);
		}

		public void OccupyWith(MovingSphere sphere)
        {
			movingSphere = sphere;
			meshRend.material.color = occupiedColor;
		}

		public void Empty()
        {
			Destroy(movingSphere.gameObject);
			movingSphere = null;

			meshRend.material.color = highlightColor;
		}
	}

}