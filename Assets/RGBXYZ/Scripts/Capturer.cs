using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RGBXYZ
{
    public class Capturer : RgbXyzCubeBase
    {
        [SerializeField] private CapturedSphere capturedSpherePrefab;

        private void Start()
        {
            InstantiateSphere();
        }

        private CapturedSphere InstantiateSphere()
        {
            var sphere = Instantiate(capturedSpherePrefab, this.transform);
            sphere.transform.localPosition = Vector3.zero;
            sphere.transform.localEulerAngles = Vector3.zero;

            sphere.Init(NumOnSide, Distance);
            return sphere;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InstantiateSphere();
            }
        }

        private void OnMouseDown()
        {
            InstantiateSphere();
        }
    }
}
