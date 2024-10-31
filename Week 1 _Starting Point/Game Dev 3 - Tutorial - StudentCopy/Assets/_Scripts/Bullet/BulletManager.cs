using System.Collections;
using UnityEngine;

namespace GameDevWithReece.Bullet
{
    public class BulletManager : MonoBehaviour
    {
        public Vector2 bulletSpeed;
        public int bulletDamage;
        public BulletData BulletData;
        void Start()
        {
            bulletSpeed = BulletData.bulletSpeed;
            bulletDamage = BulletData.bulletDamage;
        }

        private void FixedUpdate()
        {
            StartCoroutine(bulletDeath());
        }

        public IEnumerator bulletDeath()
        {
            yield return new WaitForSeconds(1f);

            Destroy(gameObject);




        }
    }
}
