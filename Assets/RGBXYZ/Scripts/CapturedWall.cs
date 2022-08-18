using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGBXYZ 
{
    public class CapturedWall : MonoBehaviour
    {
        [SerializeField] private ParticleSystem hitParticle;
        public void OnHitByBall(Vector3 hitPoint, Vector3 normal, Color ballColor)
		{
            ParticleSystem.MainModule main = hitParticle.main;
            main.startColor = ballColor;
            hitParticle.transform.position = hitPoint;
            //ParticleSystem.ShapeModule shape = hitParticle.shape;
            //shape.position = hitPoint;
            hitParticle.Emit(1);
		}
    }

}
