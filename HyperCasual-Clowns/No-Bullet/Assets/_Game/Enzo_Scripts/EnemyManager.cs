using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MJ;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject BloodSplashVFX;
    int increment = 0;
    void Start()
    {
        platformManager = this.GetComponentInParent<PlatformManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet")
        {              
            if(increment==0)
            {
                BloodSplashVFX.SetActive(true);
                Destroy(collision.gameObject);
                this.enabled = false;
                this.GetComponent<Collider>().enabled = false;
                platformManager.EnemiesDead(collision.gameObject);
                Anim.SetBool("isDead",true);
                increment = 0;
            }
            increment++;
        }
    }
}
