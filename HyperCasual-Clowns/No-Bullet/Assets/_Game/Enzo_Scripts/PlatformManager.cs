using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MJ;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Bullets;
    [SerializeField] private Transform EnemyNubPosition;
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] private LevelManager Manager;
    private PlayerController playerController;
    public Animator Anim;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Manager = FindObjectOfType<LevelManager>();
    }
    public IEnumerator BulletFire()
    {
        yield return new WaitForSeconds(2);
        Anim.SetBool("Fire",false);
        int RandomValue= Random.Range(0,Bullets.Length);
        GameObject Bullet = Instantiate(Bullets[RandomValue],EnemyNubPosition);
        Bullet.transform.rotation = Quaternion.Euler(0,180,0);       
    } 
    public void EnemiesDead(GameObject Enemy)
    {
        if(!Enemies.Contains(Enemy))
        {
            Enemies = new List<GameObject>();
        }
        if(Enemies.Count == 0)
        {
            IEnumerator LevelIncr = Manager.LevelIncremnet(1.25f);
            StartCoroutine(LevelIncr);
            playerController.isRight = false;
            playerController.BulletStack = new List<GameObject>();
            playerController.BulletHolder = new List<GameObject>();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            Anim.SetBool("Fire",true);
            PlayerController Controller = collider.GetComponent<PlayerController>();
            Controller.Manager = this;
            StartCoroutine(BulletFire());
        }
        if(collider.gameObject.name == "Enemy")
        {
            Enemies.Add(collider.gameObject);
        }
    }
}
