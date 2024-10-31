using UnityEngine;

namespace GameDevWithReece.Bullet
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData")]

    public class BulletData : ScriptableObject
    {
        public Vector2 bulletSpeed;
        public int bulletDamage;
    }
}
