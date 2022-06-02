using UnityEngine;

namespace MJ
{
    public class Bullet : MonoBehaviour
    {
        // ------- Bullet on Wall hit 
        public enum BulletType
        {
            Return,
            Shooted
        }
        // ------------ Enum Type
        [SerializeField] private BulletType Type;
        public float speed = 7;
        public bool isStrat = false;
        private void Start()
        {
            Destroy(this.gameObject, 5);
        }
        private void Update()
        {
            if (Type == BulletType.Return)
            {
                //--- Checking, if is isStrated is True
                if (isStrat)
                {
                    transform.position += transform.forward * Time.deltaTime * speed;
                }
            }
            if (Type == BulletType.Shooted)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
        }
    }
}
