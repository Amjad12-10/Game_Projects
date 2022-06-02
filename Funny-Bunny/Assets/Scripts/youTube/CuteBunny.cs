using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CuteBunny : MonoBehaviour
{
    private void Start()
    {
        this.transform.DOPunchScale(new Vector3(0.005f, 0.005f, 0.005f), 0.25f, 10, 1).SetLoops(-1);
    }

}
