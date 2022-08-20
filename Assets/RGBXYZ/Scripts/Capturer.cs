using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RGBXYZ
{
    public class Capturer : RgbXyzCubeBase
    {
        [SerializeField] private CapturedSphere capturedSpherePrefab;

        private int _numOfSpheres = 0;
        public int numOfSphere
        {
            get => _numOfSpheres;
            private set
            {
                if (_numOfSpheres != value)
                {
                    _numOfSpheres = value;
                    uiGauge.UpdateCurrentNum(_numOfSpheres);
                }
            }
        }

        private void Start()
        {
            InstantiateSphere();
        }

        private void InstantiateSphere()
        {
            if (numOfSphere == maxNumOfSphere) return;

            var sphere = Instantiate(capturedSpherePrefab, this.transform);
            sphere.transform.localPosition = Vector3.zero;
            sphere.transform.localEulerAngles = Vector3.zero;
            sphere.Init(NumOnSide, Distance);
            numOfSphere++;
        }

        private void Update()
        {
			if (Input.GetMouseButtonDown(0))
			{
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit hit)) 
                {
					if (hit.collider.TryGetComponent<CapturedWall>(out CapturedWall wall))
					{
                        InstantiateSphere();
                    }
                }
			}
		}
    }
}
