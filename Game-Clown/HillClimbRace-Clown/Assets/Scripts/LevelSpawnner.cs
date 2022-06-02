using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnner : MonoBehaviour
{
    [Header("LEVELS")]
    public GameObject Levels;
    public float LevelNum;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LevelNum; i++)
        {
            Instantiate(Levels, new Vector3(i * 200, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void spawnthere() 
    {
       
    }
}
