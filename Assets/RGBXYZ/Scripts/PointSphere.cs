using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSphere : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRend;
    [SerializeField] private float defaultSize = 0.4f;
    private float showTime = 0.5f;

    public void Init(Color color)
	{
        meshRend.transform.localScale = Vector3.zero;
        meshRend.material.color = color;
        ShowSphere();
    }



    public void ShowSphere()
	{
        meshRend.transform.DOScale(defaultSize, showTime).SetEase(Ease.OutBack);
	}

    public void HideSphere()
	{
        meshRend.transform.DOScale(0, showTime).SetEase(Ease.InBack);
	}
}
