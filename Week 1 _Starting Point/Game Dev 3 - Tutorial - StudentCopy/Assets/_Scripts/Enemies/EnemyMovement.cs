using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithReece.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        //Default move value
        private float movementSpeed = 1f;
        //Reference to enemy data
        public EnemyData enemyData;

        // Bool for if there's a bullet coming or not
        private bool incoming = false;

        //List to store Transforms to move to when dodging 
        [SerializeField] List<Transform> dodgeTransforms; 
        
        private void Start()
        {

            movementSpeed = enemyData.shipSpeed;

            //Finds both Dodge Transforms and adds them to the list
            dodgeTransforms.Add(transform.Find("Dodge A"));
            dodgeTransforms.Add(transform.Find("Dodge B"));

        }

        private void Update()
        {
            //see if there's a bullet coming 
            incomingBullet();
            Movement();
        }

        private void FixedUpdate()
        {
            //Does not execute the rest of the code if this check is true
            if (Managers.GameManager.isGameOn == false) return;



        }

        void incomingBullet()
        {

            //Casts a ray down from the enemy searching for a collider with the layerMask of Bullet
            RaycastHit2D bullet = Physics2D.Raycast(transform.position, Vector2.down, 8, LayerMask.GetMask("Bullet"));

            //If there's no collider do nothing
            if (bullet.collider == null)
            {
                incoming = false;
            }
            //If that collider has the tag Bullet
            else if (bullet != null && bullet.collider.gameObject.tag == "Bullet")
            {
               incoming = true;
            }
        }
        void Movement()
        {
            //To store the position before the movement
            Vector2 pos = transform.position;

            if (!incoming) // if no bullet 
            {
                //To move the ship down
                pos.y -= movementSpeed * Time.deltaTime;
                //To actually move the ship
                transform.position = pos;
            }
            else //if there is a bullet 
            {
                //generate a random number based on the amount of items in dodgeTransforms
                int randomInt = Random.Range(0, dodgeTransforms.Count);

                //new position to move to is equal to randomInt in dodgeTransforms
                pos.x = dodgeTransforms[randomInt].position.x ;
                transform.position = pos;
            }
        }


    }
}