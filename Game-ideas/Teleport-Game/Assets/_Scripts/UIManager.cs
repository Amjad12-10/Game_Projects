using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject transition;
    public GameObject Complete;
    // Start is called before the first frame update
    void Start()
    {
        transition.transform.DOScale(0.2f, 1).SetEase(Ease.Linear).OnComplete(() => transition.SetActive(false) );
    }
    public void OnWin()
    {
        transition.SetActive(true);
        Complete.SetActive(true);
        transition.transform.DOScale(15, 1).SetEase(Ease.Linear);
    }
}
