using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGBXYZ {

    public class MovingSphere : MonoBehaviour
    {
        private MeshRenderer meshRend;
        private int numOnSide;
        private float distance;

        void Start()
        {
            RgbXyzCubeCreator rgbXyz = GetComponentInParent<RgbXyzCubeCreator>();
            numOnSide = rgbXyz.NumOnSide;
            distance = rgbXyz.Distance;

            meshRend = GetComponentInChildren<MeshRenderer>();
        }


        void Update()
        {
            Vector3 currentPos = transform.position;
            float xValue = currentPos.x + ((numOnSide - 1) * distance / 2f);
            float yValue = currentPos.y + ((numOnSide - 1) * distance / 2f);
            float zValue = currentPos.z + ((numOnSide - 1) * distance / 2f);
            Color color = new Color(xValue /(numOnSide - 1) * 2f, yValue / (numOnSide - 1) * 2f, zValue /(numOnSide - 1) * 2f);

            meshRend.material.color = color;
        }
    }

}
