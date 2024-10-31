using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithReece.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] GameObject enemyBullet;
        [SerializeField] GameObject enemyMuzzle;
        [SerializeField] List<Transform> firePoints;
        [SerializeField] Vector2 bulletSpeed;
        private int randomInt;
        private float coolDown = 2f;

        private bool canFire = true;
        private void Start()
        {
            firePoints.Add(transform.Find("Fire Point 1"));
            firePoints.Add(transform.Find("Fire Point 2"));
            firePoints.Add(transform.Find("Fire Point 3"));

        }
        private void Update()
        {
            //Generates randomInt to select random firepoint 
            int randomInt = Random.Range(0, firePoints.Count);
            attackPlayer();
        }
        private void attackPlayer()
        {
            RaycastHit2D player = Physics2D.Raycast(transform.position, Vector2.down, 15, LayerMask.GetMask("Player"));

            if (player.collider == null)
            {
                return;
            }
            else if (player != null && player.collider.gameObject.tag == "Player" && canFire)
            {
                Bullet();
                MuzzleFlash();
                canFire = false;
                StartCoroutine(CoolDown());
            }
        }


        private void Bullet()
        {
            //Spqwns the bullet
            var spawnedBullet = Instantiate(enemyBullet, firePoints[randomInt].position, Quaternion.identity);
            //Gets its rigidbody
            Rigidbody2D bulletRb = spawnedBullet.GetComponent<Rigidbody2D>();
            //Adds force to it so it can be actually yeeted away
            bulletRb.AddForce(-bulletSpeed, ForceMode2D.Impulse);
        }

        private void MuzzleFlash()
        {
            //To get a random value so we can use it to give the muzzle flash a random rotation
            float randomRotation = Random.Range(0, 360);
            //Spawns the muzzleflash and stores it into a variable 
            var muzzleFlash = Instantiate(enemyMuzzle, firePoints[randomInt].transform.position, Quaternion.Euler(0, 0, randomRotation));
            //Destroys the muzzleflash game object since we do not need it anymore
            Destroy(muzzleFlash, 1f);
        }
        private IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(coolDown);
            canFire = true;
        }

    }
}
