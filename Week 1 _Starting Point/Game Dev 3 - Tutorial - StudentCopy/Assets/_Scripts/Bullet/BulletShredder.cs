using UnityEngine;

namespace GameDevWithReece.Bullet
{
    public class BulletShredder : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Bullet")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}