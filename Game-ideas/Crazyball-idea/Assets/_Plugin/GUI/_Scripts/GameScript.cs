using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameScript : MonoBehaviour
{
  
    [Space]
    public Text CoinsCollect;

    [Header("Ease")]
    [Space]
    public Ease ease;
    public Ease linear;

    [Header("WinComponents")]
    [Space]
    public GameObject WinEmoji;
    [Space]
    public GameObject LoopBackGround;
    [Space]
   
    [Header("Panels")]
    [Space]
    public GameObject MainGamePanel;
    [Space]
    public GameObject MenuPanel;
    [Space]
    public GameObject GamePanel;
    [Space]
    public GameObject Winpanel;
    [Space]
    public RectTransform SettingPanel;
    [Space]
    public RectTransform LevelPanel;
    [Space]
    public RectTransform Amazing;

    //--------------------------------------------------------------managers
    //------------------
    private Ball _ballmanager;

    // Start is called before the first frame update
    
    void Start()
    {
        _ballmanager = FindObjectOfType<Ball>();
    }
    public void Levels() 
    {
        MenuPanel.SetActive(false);
        Upslide(LevelPanel);
    }
    public void TapToMove() 
    {
       _ballmanager.enabled = true;
       MainGamePanel.SetActive(true);
       MenuPanel.SetActive(false);
    }
    public void Next() 
    {
        Debug.Log("SceneReload" + "With PlayerPrefs");
    }
    public void Restart() 
    {
        Debug.Log("SceneReload" + "Without PlayerPrefs");
    }
 
    #region Win Loss
   
    public void Onwin() 
    {
        Invoke("Amaze", 1.5f);
    }
    void Amaze()
    {
        MenuPanel.SetActive(false);
        Winpanel.SetActive(true);
        LoopBackGround.transform.DORotate(new Vector3(0, 0, 180), 2).SetLoops(-1).SetEase(linear);
        Amazing.DOAnchorPosY(300, 2, false).SetEase(ease);
        WinEmoji.transform.DOScale(2f, 2).SetEase(ease);
        Amazing.gameObject.SetActive(false);
    }
    #endregion Win Loss
    #region Setting
    public void Setting() 
    {
        Debug.Log("Set");
        MenuPanel.SetActive(false);
        Downslide(SettingPanel);
        
    }
    public void SettingExit() 
    {
      //  SettingPanel.DOAnchorPosX(2000, 1f, false);
        MenuPanel.SetActive(true);
        ReturnUp(SettingPanel);
        ReturnDown(LevelPanel);
    }

    #endregion Setting
    #region Dotween
    void RightSlide(RectTransform Obj) 
    {
        SettingPanel.DOAnchorPosX(0, 1f, false);
    }
    void ReturnRight(RectTransform Obj) 
    {
        Obj.DOAnchorPosX(2000, 1f, false);
    }
    void Upslide(RectTransform obj) 
    {
        obj.DOAnchorPosY(0, 1f, false);
    }
    void ReturnDown(RectTransform obj) 
    {
        obj.DOAnchorPosY(-2000, 1f, false);
    }
    void Downslide(RectTransform obj)
    {
        obj.DOAnchorPosY(0, 1f, false);
    }
    void ReturnUp(RectTransform obj)
    {
        obj.DOAnchorPosY(2000, 1f, false);
    }
    #endregion Dotween

}
