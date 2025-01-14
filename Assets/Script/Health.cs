using Script.EnemyScript;
using UnityEngine;

namespace Script
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float startingHealth;
        public float currentHealth { get; set; }
        private Animator _animator;
        private bool _dead;

        private void Awake()
        {
            currentHealth = startingHealth;
            _animator = GetComponent<Animator>();
        }

        public void TakeDamage(float damage)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

            if (currentHealth > 0)
            {
                //player hurt
                _animator.SetTrigger("hurt");
                //iframes
            }
            else
            {
                //player dead
                if (!_dead)
                {
                    _animator.SetTrigger("die");
                    //Player
                    if (GetComponent<PlayerMovement>() != null)
                        GetComponent<PlayerMovement>().enabled = false;
                    //Enemy
                    if (GetComponentInParent<EnemyPatrol>()!= null)
                        GetComponentInParent<EnemyPatrol>().enabled = false;
                    gameObject.SetActive(false);
                    // if (GetComponent<MeeleEnemy>() != null)
                    //     GetComponent<MeeleEnemy>().enabled = false;
                        
                    _dead = true;
                }
            }
        }
        // Update is called once per frame
        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.A))
        //     {
        //         Debug.Log("damage");
        //         TakeDamage(10);
        //     }
        // }
    }
}