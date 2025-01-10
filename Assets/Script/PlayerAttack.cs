using UnityEngine;

namespace Script
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float attackCooldown;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject[] fireball;

        private float _cooldownTimer = Mathf.Infinity;
        private Animator _animator;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            //left mouse button press
            if (Input.GetMouseButtonDown(0) && _cooldownTimer > attackCooldown && _playerMovement.CanAttack1)
            {
                Attack();
                Debug.Log("Attack");
            }


            _cooldownTimer += Time.deltaTime;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Attack()
        {
            _animator.SetTrigger("attack");
            _cooldownTimer = 0;

            fireball[FindFireball()].transform.position = firePoint.position;
            fireball[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }

        private int FindFireball()
        {
            for (int i = 0; i < fireball.Length; i++)
            {
                if (!fireball[i].activeInHierarchy)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}