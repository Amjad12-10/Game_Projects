using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamControl : MonoBehaviour
{
    public float speed = 0;

    void Start()
    {
        transform.DOMove(new Vector3(0, 18, -18), 2, false);
    }

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
