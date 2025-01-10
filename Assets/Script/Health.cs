using UnityEngine;

namespace Script
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float startingHealth;
        public float currentHealth {get; private set;}

        private void Awake()
        {
            currentHealth = startingHealth;
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void TakeDamage(float damage)
        { 
            currentHealth -= Mathf.Clamp(currentHealth - damage, 0, startingHealth);
            if (currentHealth > 0)
            {
                //player hurt
            }
            else
            {
                //player dead
            }
            
        }
    }
}