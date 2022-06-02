using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform GunPointer;
    [SerializeField] Transform MainGun;

    [SerializeField] GameObject Bullet;
    float Dire ;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(Bullet,GunPointer.transform.position,Quaternion.identity);

        }

        float Hori = Input.GetAxis("Horizontal");


        if(Hori<0){
        Dire += 0.75f;
        }
        else if(Hori>0){
        Dire -= 0.75f;
        }
        MainGun.transform.rotation = Quaternion.Euler(0,0,Dire);

        // //--------- Direction
        // Vector2 Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        // MainGun.transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
