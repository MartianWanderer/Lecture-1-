using UnityEngine;

namespace GameDevWithReece.Enemy
{
    public class EnemyVisual : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        public EnemyData enemyData;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = enemyData.shipSprite;
        }
    }
}