using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RGBXYZ
{
    public class Capturer : RgbXyzCubeBase
    {
        [SerializeField] private CapturedSphere capturedSpherePrefab;

        //[SerializeField] private ParticleSystem hitParticle;

        private void Start()
        {
            InstantiateSphere();
        }

        private CapturedSphere InstantiateSphere()
        {
            var sphere = Instantiate(capturedSpherePrefab, this.transform);
            sphere.transform.localPosition = Vector3.zero;
            sphere.transform.localEulerAngles = Vector3.zero;
            //sphere.onHitWall += OnHitWall;

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

  //      private void OnHitWall(HitEventArgs hitEventArgs)
		//{
  //          ParticleSystem.MainModule main = hitParticle.main;
  //          main.startColor = hitEventArgs.color;
  //          hitParticle.transform.position = hitEventArgs.hitPoint;
  //          hitParticle.transform.rotation = Quaternion.LookRotation(hitEventArgs.normal);
  //          hitParticle.Emit(1);
		//}

        private void OnMouseDown()
        {
            InstantiateSphere();
        }
    }
}
