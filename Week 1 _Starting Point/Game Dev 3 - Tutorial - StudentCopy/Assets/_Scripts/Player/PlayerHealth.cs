using UnityEngine;
using GameDevWithReece.Bullet;
using GameDevWithReece.Managers;

namespace GameDevWithReece.player
{
    public class PlayerHealth : MonoBehaviour
    {

        //Default life value
        [SerializeField] int playerHP = 10;
        [SerializeField] GameManager GameManager;
        [SerializeField] TitleMover TitleMover;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy Bullet")
            {
                //Will remove health based off of the enemy bullets scriptable object bulletDamage value
                RemoveHp(collision.gameObject.GetComponent<BulletManager>().bulletDamage);
                //Will destroy the bullet
                Destroy(collision.gameObject);

            }
        }

        public void RemoveHp(int hpToRemove)
        {
            //Destroys the enemyShip if the hit brings it tp 0 or below
            if ((playerHP - hpToRemove) <= 0)
            {
                //You can add a timer to it by putting a comma and a float variable Example:Destroy(gameObject, 0.5f)
                GameManager.GameIsOff();
                TitleMover.PlayerDead();
            }
            else
            {
                //Removes the required hp
                playerHP -= hpToRemove;
            }
        }
    }
}
