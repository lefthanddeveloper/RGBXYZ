using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGBXYZ {

    public class MovingSphere : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRend;

		private int numOnSide;
		private float distance;
		private float startTime;
		private float sineWaveHeight;
		private bool isInitialized = false;
        public void Init(int numOnSide, float distance, float lowestY, float highestY)
		{
			this.numOnSide = numOnSide;
			this.distance = distance;
			sineWaveHeight = (highestY - lowestY) / 2f;

			startTime = Time.time;
			isInitialized = true;
		}

        void Update()
        {
			if (!isInitialized) return;
			UpdatePosition();
			UpdateColor();
		}

		private void UpdatePosition()
		{
			float passedTime = Time.time - startTime;
			float y = sineWaveHeight * Mathf.Sin(passedTime + 1.5f * Mathf.PI);
			Vector3 curPos = transform.localPosition;
			curPos.y = y;
			this.transform.localPosition = curPos;
		}

		private void UpdateColor()
		{
			Vector3 currentPos = transform.localPosition;
			float xValue = currentPos.x + ((numOnSide - 1) * distance / 2f);
			float yValue = currentPos.y + ((numOnSide - 1) * distance / 2f);
			float zValue = currentPos.z + ((numOnSide - 1) * distance / 2f);
			Color color = new Color(xValue / (numOnSide - 1) * 2f, yValue / (numOnSide - 1) * 2f, zValue / (numOnSide - 1) * 2f);

			meshRend.material.color = color;
		}
    }

}
