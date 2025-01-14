using UnityEngine;

namespace Script.EnemyScript
{
    public class EnemyPatrol : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        [Header("Patrol Point")] [SerializeField]
        private Transform leftEdge;

        [SerializeField] private Transform rightEdge;

        [Header("Enemy")] [SerializeField] private Transform enemy;

        [Header("Movement Parameters")] [SerializeField]
        private float speed;

        private Vector2 _initialScale;
        private bool _movingLeft = false;
        private int _direction = 1;

        private void Awake()
        {
            _initialScale = enemy.localScale;
            RotationToFace();
        }

        private void Update()
        {
            if (_movingLeft)
            {
                if (enemy.position.x >= leftEdge.position.x)
                {
                      MoveInDirection();
                }
                else
                {
                    //Change direction
                    DirectionChange();
                    RotationToFace();

                }
            }
            else
            {
                if (enemy.position.x <= rightEdge.position.x)
                {
                   
                    MoveInDirection();
                }
                else
                {
                    //Change direction
                    DirectionChange();
                    RotationToFace();

                }
                
            }
        }

        private void DirectionChange()
        {
            _movingLeft = !_movingLeft;
           _direction = -_direction;
            
        }

        private void RotationToFace()
        {
            var rotationY = _movingLeft ? 0f : 180f;
            enemy.rotation = Quaternion.Euler(0f, rotationY, 0f);
            
        }
        private void MoveInDirection()
        {
            //Make the enemy face direction
            //enemy.localScale = new Vector2(Mathf.Abs(_initialScale.x)* direction, _initialScale.y);
            
            //Move in the direction
            enemy.position = new Vector2(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y);
        }
    }
}