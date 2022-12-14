using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RGBXYZ
{
	public class PointMover : RgbXyzCubeBase
	{
		[SerializeField] private MovingSphereInstantiator sphereInstantiator;
		[SerializeField] private MovingSphere movingSpherePrefab;

		public float highestY => (NumOnSide - 1) * Distance / 2f;
		public float lowestY => -highestY;

		private int _numOfSpheres = 0;
		public int numOfSphere
		{
			get => _numOfSpheres;
			private set
			{
				if(_numOfSpheres != value)
				{
					_numOfSpheres = value;
					uiGauge.UpdateCurrentNum(_numOfSpheres);
				}
			}
		}
		private void Start()
		{
			StartCoroutine(InstantiateInstantiator());
		}

		private IEnumerator InstantiateInstantiator()
		{
			var term = new WaitForSeconds(0.001f);

			for(int z =0; z <NumOnSide; z++)
			{
				for(int x=0; x < NumOnSide; x++)
				{
					Vector3 pos = new Vector3((float)x * Distance - ((float)(NumOnSide - 1) * Distance / 2f), lowestY * 1.1f, (float)z * Distance - ((float)(NumOnSide - 1) * Distance / 2f));
					var instantiator = Instantiate(sphereInstantiator, this.transform);
					instantiator.transform.localPosition = pos;
					instantiator.transform.localEulerAngles = Vector3.zero;
					instantiator.onClick += OnClickInstantiator;

					yield return term;
				}
			}
		}

		private void OnClickInstantiator(MovingSphereInstantiator instantiator)
		{
			

            if (instantiator.IsOccupied)
            {
				instantiator.Empty();
				numOfSphere--;
            }
            else
            {
				if (numOfSphere == maxNumOfSphere) return;
				Vector3 pos = new Vector3(instantiator.transform.position.x, lowestY, instantiator.transform.position.z);
				var movingSphere = Instantiate(movingSpherePrefab, this.transform);
				movingSphere.transform.localPosition = pos;
				movingSphere.transform.localEulerAngles = Vector3.zero;
				movingSphere.Init(NumOnSide, Distance, lowestY, highestY);
				instantiator.OccupyWith(movingSphere);
				numOfSphere++;
			}
		}
	}
}
