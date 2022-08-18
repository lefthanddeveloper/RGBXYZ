using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RGBXYZ
{
	public struct HitEventArgs
	{
		public HitEventArgs(Vector3 hitPoint, Vector3 normal, Color color)
		{
			this.hitPoint = hitPoint;
			this.normal = normal;
			this.color = color;
		}
		public Vector3 hitPoint { get; }
		public Vector3 normal { get; }
		public Color color { get; }
	}

    public class CapturedSphere : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRend;

		private Rigidbody rigid;
		private int numOnSide;
		private float distance;

		private Vector3 direction;
		public float speed = 5f;
		private string wallTag = "Wall";

		public Action<HitEventArgs> onHitWall;
		public void Init(int numOnSide, float distance)
		{
			rigid = GetComponent<Rigidbody>();

			this.numOnSide = numOnSide;
			this.distance = distance;

			direction = Random.onUnitSphere;

			rigid.velocity = direction * speed;
		}

        private void Update()
        {
			//Move();
            UpdateColor();
        }

        private void OnCollisionEnter(Collision collision)
        {
			ContactPoint contactPoint = collision.GetContact(0);
            Vector3 normal = contactPoint.normal;
            direction = Vector3.Reflect(direction, normal);
			rigid.velocity = direction * speed;

			if(collision.transform.TryGetComponent<CapturedWall>(out CapturedWall wall))
			{
				wall.OnHitByBall(contactPoint.point, normal, meshRend.material.color);
			}


			//if (collision.collider.CompareTag(wallTag))
			//{
			//	//onHitWall?.Invoke(new HitEventArgs(contactPoint.point, normal, meshRend.material.color));
				

			//}
        }

        private void Move()
        {
			this.transform.position += direction * speed * Time.deltaTime;
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
