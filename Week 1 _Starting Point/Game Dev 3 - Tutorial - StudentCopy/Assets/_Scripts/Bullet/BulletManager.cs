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
    }
}
