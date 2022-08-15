using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGBXYZ 
{
    public class RgbXyzCubeCreator : MonoBehaviour
    {
        [SerializeField] private float distance = 1f;

        [SerializeField] private GameObject spherePrefab;

        
        private int numOnSide = 10;
        private Coroutine createCor;

        public float Distance => distance;
        public int NumOnSide => numOnSide;
        void Start()
        {
            //createCor = StartCoroutine(CreateRgbXyzCube()); 
        }

        private IEnumerator CreateRgbXyzCube()
		{
            var term = new WaitForSeconds(0.001f);

            for(int g =0; g<numOnSide; g++)
			{
            for(int b =0; b< numOnSide; b++)
				{
                    for(int r =0; r< numOnSide; r++)
					{
                        Vector3 pos = new Vector3((float)r * distance - ((float)(numOnSide-1) * distance/2f), (float)g * distance - ((float)(numOnSide - 1) * distance / 2f), (float)b * distance - ((float)(numOnSide - 1) * distance / 2f));
                        GameObject point = Instantiate(spherePrefab, pos, Quaternion.identity, this.transform);
                        point.GetComponent<MeshRenderer>().material.color = new Color32((byte)(r * 255f / numOnSide), (byte)(g * 255f / numOnSide), (byte)(b * 255f / numOnSide),255) ;
                        yield return term;
					}
				}
			}

            createCor = null;
		}

		private void OnDestroy()
		{
			if(createCor != null)
			{
                StopCoroutine(createCor);
			}
		}

		private void OnDrawGizmos()
		{
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one * numOnSide * distance);
		}
	}

}

