using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject[] level;
    public GameObject[] locks;
 
   [HideInInspector] public int levesel;

    public Text LevNum;
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindGameObjectsWithTag("Levels");
        locks = GameObject.FindGameObjectsWithTag("Lock");
        
        levesel = PlayerPrefs.GetInt("Level", 1);
        LevNum.text = "LEVEL : " + levesel.ToString();
        for (int i = 0; i < level.Length; i++)
        {
            level[i].GetComponent<Button>().interactable = false;
            level[i].GetComponentInChildren<Text>().text = "".ToString();
            if (!level[i].GetComponent<Button>().interactable)
            {
                locks[i].gameObject.SetActive(true);
               
            }   

        }
        for (int i = 0; i < levesel; i++) 
        {
            level[i].GetComponent<Button>().interactable = true;
            level[i].GetComponentInChildren<Text>().text = (i+1).ToString();
            if (level[i].GetComponent<Button>().interactable)
            {
                locks[i].gameObject.SetActive(false);
            }
        }
    }
 
    public void Next()
    {
        levesel++;
        PlayerPrefs.SetInt("Level", levesel);
        SceneManager.LoadScene(0);
       
    }
    public void Scene(int LevelNum) 
    {
        Debug.Log("You are in " + LevelNum + "Level");
       
    }
    private void Update()
    {
    }
}
