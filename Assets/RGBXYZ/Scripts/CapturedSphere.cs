using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RGBXYZ
{
    public class CapturedSphere : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRend;

		private Rigidbody rigid;
		private int numOnSide;
		private float distance;

		private Vector3 direction;
		private float speed = 2f;

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
            Vector3 normal = collision.GetContact(0).normal;

            direction = Vector3.Reflect(direction, normal);

			rigid.velocity = direction * speed;
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
