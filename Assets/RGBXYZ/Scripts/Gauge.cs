using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RGBXYZ 
{
    public class Gauge : MonoBehaviour
    {
        [SerializeField] private Image fillImage;

        private int maxNum;
        private int currentNum;
        public void Init(int maxNum)
		{
            this.maxNum = maxNum;

		}

        public void UpdateCurrentNum(int currentNum)
		{
            this.currentNum = currentNum;
		}
        
        void LateUpdate()
        {
            fillImage.fillAmount = (float)currentNum / maxNum;
        }
    }

}
