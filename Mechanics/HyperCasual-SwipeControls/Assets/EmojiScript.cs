using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EmojiScript : MonoBehaviour
{
  
    public float R1 = 20;
    public float R2 = -20;
    // Start is called before the first frame update
    void Start()
    {
        EmojiStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EmojiStart()
    {
        transform.DORotate(new Vector3(30, R1, 0), 1, RotateMode.Fast).OnComplete(() => EmojiEnd());
    }
    void EmojiEnd()
    {
        transform.DORotate(new Vector3(30, R2, 0), 1, RotateMode.Fast).OnComplete(() => EmojiStart());
    }
}
