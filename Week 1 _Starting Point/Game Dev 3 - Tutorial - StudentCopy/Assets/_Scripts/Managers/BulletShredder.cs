using UnityEngine;

namespace GameDevWithReece.Managers
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