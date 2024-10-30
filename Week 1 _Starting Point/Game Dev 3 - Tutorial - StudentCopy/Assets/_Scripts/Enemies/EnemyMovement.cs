using UnityEngine;

namespace GameDevWithReece.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        //Default move value
        private float movementSpeed = 1f;
        //Reference to enemy data
        public EnemyData enemyData;

        
        private void Start()
        {

            movementSpeed = enemyData.shipSpeed;

        }

        private void Update()
        {
            incomingBullet();
        }
        private void FixedUpdate()
        {
            //Does not execute the rest of the code if this check is true
            if (Managers.GameManager.isGameOn == false) return;
            //To move the ship
            Movement();
        }

        void incomingBullet()
        {
            Debug.DrawRay(transform.position, Vector3.zero);
        }
        void Movement()
        {
            //To store the position before the movement
            Vector2 pos = transform.position;
            //To move the ship down
            pos.y -= movementSpeed * Time.fixedDeltaTime;
            //To actually move the ship
            transform.position = pos;
        }
    }
}