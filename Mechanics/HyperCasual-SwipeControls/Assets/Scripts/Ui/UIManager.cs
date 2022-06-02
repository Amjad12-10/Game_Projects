using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{   [Header("UI Panels")]
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject DeadMenu;
    public GameObject WinMenu;
    public GameObject GamePanel;
    public GameObject ShopPanel;

    [Header("Player")]
    //public GameObject Player;
    public SwipeTest PlayerScript;
    [Header("Camera")]
    public CamControl Cam;
    [Header("Police")]
    public policeScript Police;

    [Header("Settings")]
    public GameObject Settings;
    public float Set_time = 1;
 
    [Header("Recttransfrom")]
    public RectTransform Info;
    public RectTransform Volume;
    public RectTransform Close;

    [Header("Animator")]
    public Animator Anim;
    public Animator PoliceAnim;
    public void settings()
    {
        Settings.transform.DORotate(new Vector3(0, 0, -90), Set_time, RotateMode.Fast);
        Volume.DOAnchorPosY(-185,0.5f, false);
        Info.DOAnchorPosY(-285, 0.5f, false);
        Close.DOAnchorPosY(-360, 0.5f, false);
    }
    public void SettingClose()
    {
        Settings.transform.DORotate(new Vector3(0, 0, 0), Set_time, RotateMode.Fast);
        Info.DOAnchorPosY(200, 1, false);
        Volume.DOAnchorPosY(200, 1, false);
        Close.DOAnchorPosY(200, 1, false);
    }
    public void Play()
    {
        Police.sp = 19;
        PoliceAnim.SetBool("Run", true);
        Anim.SetBool("Run", true);
        Cam.speed = 20;
        PlayerScript.speed = 20;
        MainMenu.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void Pause()
    {
        Cam.speed = 0;
        PlayerScript.speed = 0;
        GamePanel.SetActive(false);
        PauseMenu.SetActive(true);
    }
    public void PauseGameClose()
    {
        Cam.speed = 20;
        PlayerScript.speed = 20;
        GamePanel.SetActive(true);
        PauseMenu.SetActive(false);

    }
    public void Home()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        //MainMenu.SetActive(true);
    }
    public void ShopClose()
    {
        MainMenu.SetActive(true);
        ShopPanel.SetActive(false);
    }
    public void shop()
    {
        MainMenu.SetActive(false);
        ShopPanel.SetActive(true);
    }
    public void Dead()
    {
        
        
        
    }
    public void Update()
    {
        Dead();
    }
    void Start()
    {
        Invoke("mainMenu", 2);
    }
    void mainMenu()
    {
        MainMenu.SetActive(true);
    }
}
