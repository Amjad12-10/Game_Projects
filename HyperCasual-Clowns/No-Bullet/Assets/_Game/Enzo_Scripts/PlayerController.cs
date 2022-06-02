using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace MJ
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public bool isRight = true;
        [Header("RayCast")]
        [SerializeField] private LayerMask Layer;
        [SerializeField] private float RayCastDistance;
        [Header("Bullet")]
        [SerializeField] private float BulletDistance;
        [SerializeField] public List<GameObject> BulletHolder,BulletStack;
        [SerializeField] private GameObject BulletPrefab;
        [Header("Hands")]
        [SerializeField]private GameObject RigthHand;
        [SerializeField]private GameObject leftHand;
        [Header("VFX")]
        [SerializeField] private GameObject Hole;
        [SerializeField] private GameObject BigHole;
        [SerializeField] private GameObject Hole2;
        [SerializeField] private GameObject BigHole2;
        private int MaxHolder, increment;
        private Vector3 startPosition = new Vector3();
        private RaycastHit hit;
        private bool isLeftDown,isMouseDown;
        public PlatformManager Manager;
        private Camera Cam;
        private void Start()
        {
            Cam = Camera.main;
        }
        private void Update()
        {
            if(isRight)
            {
                Right();
            }
            else
            {
                Left();
            }
        }
        private void BulletCapture(GameObject Bullet)
        {
            BulletHolder.Add(Bullet);
            Bullet BulletScript = Bullet.GetComponent<Bullet>();
            BulletScript.isStrat = false;
            Bullet.SetActive(false);
        }
        GameObject HoleDummy ;
        GameObject BigHoleDummy;
        private void Left()
        {
            if(!isLeftDown)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    isLeftDown = true;                    
                    HoleDummy = Instantiate(Hole);
                    BigHoleDummy = Instantiate(BigHole);
                    var Pos = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Cam.transform.localPosition.z+25));
                    BigHoleDummy.transform.position = Pos + Vector3.up * 5;
                    leftHand.transform.DORotate(new Vector3(45,20,0),0.25f).OnComplete(() => leftHand.transform.DOPunchScale(new Vector3(0.05f,0.05f,0.05f),0.5f,2,1).SetLoops(-1));
                }
            }
            if(isLeftDown)
            {
                Vector3 MousePosition = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Cam.transform.localPosition.z+4));
                HoleDummy.transform.position = MousePosition;
                if(Physics.Raycast(MousePosition,transform.TransformDirection(Vector3.forward),out hit,RayCastDistance,Layer))
                {
                    hit.collider.enabled = false;
                    BulletCapture(hit.collider.gameObject);
                } 
            }
            if(Input.GetMouseButtonUp(0))
            {
                DOTween.Clear();
                leftHand.transform.DORotate(new Vector3(90,20,0),0.25f);
                isLeftDown = false;
                Destroy(HoleDummy);
                Destroy(BigHoleDummy);
                if(BulletHolder.Count > 0)
                {
                    isRight = true;  
                }
                else
                {
                    if (Manager != null)
                    {
                        Manager.Anim.SetBool("Fire", true);
                        IEnumerator Fire = Manager.BulletFire();
                        StartCoroutine(Fire);
                    }
                }
            }
        }
        private GameObject BulletInstance(Vector2 newPosition)
        {
            if(BulletHolder[0] != null)
                BulletHolder.RemoveAt(0);
            Vector3 newWorldPosition = new Vector3(newPosition.x,newPosition.y,Cam.transform.position.z+5);
            GameObject BulletClown = Instantiate(BulletPrefab);                
            if(!BulletStack.Contains(BulletClown))
                BulletStack.Add(BulletClown);
            BulletClown.name = "Bullet";
            BulletClown.layer = LayerMask.NameToLayer("Default");
            BulletClown.transform.position = newWorldPosition;
            return BulletClown;
        }
        GameObject HoleDummy2;
        GameObject BigHoleDummy2;
        private void Right()
        {
            if(Input.GetMouseButtonDown(0))
            {
                RigthHand.transform.DORotate(new Vector3(45,-20,0),0.25f).OnComplete(() => RigthHand.transform.DOPunchScale(new Vector3(0.05f,0.05f,0.05f),0.5f,2,1).SetLoops(-1));
                increment = 0;
                HoleDummy2 = Instantiate(Hole2);
                BigHoleDummy2 = Instantiate(BigHole2);
                var Pos = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Cam.transform.localPosition.z + 25));
                BigHoleDummy2.transform.position = Pos + Vector3.up * 5;
                MaxHolder = BulletHolder.Count;
                isMouseDown = true;
                startPosition = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Cam.transform.localPosition.z+4));
            }
            if(isMouseDown)
            {
                Vector3 newPosition = new Vector3();
                newPosition = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Cam.transform.localPosition.z+4));
                HoleDummy2.transform.position = newPosition;
                float Distance = Vector2.Distance(startPosition,newPosition);
                if(increment < MaxHolder)
                {
                    if(Distance >= BulletDistance)
                    {
                        BulletInstance(newPosition);
                        startPosition = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Cam.transform.localPosition.z+4));
                        increment++;
                    }
                }
            }
            if(Input.GetMouseButtonUp(0))
            {
                DOTween.Clear();
                RigthHand.transform.DORotate(new Vector3(90,-20,0),0.25f);
                Destroy(HoleDummy2);
                Destroy(BigHoleDummy2);
                isMouseDown = false;
                if(BulletHolder.Count > 0)
                    isRight = true;
                else
                {
                    isRight = false;
                    isLeftDown = false;
                }
                if(BulletStack.Count!=0)
                {
                    int Max = BulletStack.Count;
                    for(int i =0; i< Max ;i++)
                    {
                       Bullet BulletScript = BulletStack[i].GetComponent<Bullet>();
                       BulletScript.isStrat = true;
                       BulletScript.speed = 10;
                       if(i==(Max-1))
                        BulletStack = new List<GameObject>();
                    }
                }
            }
        }

    }
}
