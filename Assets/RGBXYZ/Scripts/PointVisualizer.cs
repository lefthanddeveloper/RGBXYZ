using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGBXYZ 
{
    public class PointVisualizer : RgbXyzCubeBase
    {
		[Header("[ Point Visualizer ]")]
        [SerializeField] private PointSphere pointSpherePrefab;

        private List<PointSphere> createdSpheres = new List<PointSphere>();

		protected override void Awake()
		{
			maxNumOfSphere = NumOnSide * NumOnSide * NumOnSide;
			base.Awake();
		}

		void Start()
        {
            StartCoroutine(CreateRgbXyzCube(OnCreationDone));
        }

		private IEnumerator CreateRgbXyzCube(Action done)
		{
			var term = new WaitForSeconds(0.02f);

			for (int g = 0; g < NumOnSide; g++)
			{
				for (int b = 0; b < NumOnSide; b++)
				{
					for (int r = 0; r < NumOnSide; r++)
					{
						Vector3 pos = new Vector3((float)r * Distance - ((float)(NumOnSide - 1) * Distance / 2f), (float)g * Distance - ((float)(NumOnSide - 1) * Distance / 2f), (float)b * Distance - ((float)(NumOnSide - 1) * Distance / 2f));
						PointSphere pointSphere = Instantiate(pointSpherePrefab, this.transform);
						pointSphere.transform.localPosition = pos;
						pointSphere.transform.localEulerAngles = Vector3.zero;
						float x = (pos.x + ((NumOnSide - 1) * Distance / 2f)) / (NumOnSide - 1) * 2f;
						float y = (pos.y + ((NumOnSide - 1) * Distance / 2f)) / (NumOnSide - 1) * 2f;
						float z = (pos.z + ((NumOnSide - 1) * Distance / 2f)) / (NumOnSide - 1) * 2f;
						pointSphere.Init(new Color(x, y, z));
						createdSpheres.Add(pointSphere);
						uiGauge.UpdateCurrentNum(createdSpheres.Count);
						yield return term;
					}
				}
			}
			yield return new WaitForSeconds(1.0f);
			done?.Invoke();
		}

		private void OnCreationDone()
		{
			StartCoroutine(HideCor());
		}

		private IEnumerator ShowCor()
		{
			var term = new WaitForSeconds(0.02f);
			for (int i = 0; i < createdSpheres.Count; i++)
			{
				createdSpheres[i].ShowSphere();
				uiGauge.UpdateCurrentNum(i + 1);
				yield return term;
			}

			yield return new WaitForSeconds(1.0f);
			StartCoroutine(HideCor());
		}

		private IEnumerator HideCor()
		{
			var term = new WaitForSeconds(0.02f);
			for (int i = createdSpheres.Count - 1; i >= 0; i--)
			{
				createdSpheres[i].HideSphere();
				uiGauge.UpdateCurrentNum(i);
				yield return term;
			}

			yield return new WaitForSeconds(1.0f);
			StartCoroutine(ShowCor());
		}

		private void OnDestroy()
		{
			StopAllCoroutines();
		}
	}

}
