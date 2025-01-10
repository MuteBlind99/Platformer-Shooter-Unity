using UnityEngine;

namespace Script
{
    public class Health : MonoBehaviour
    {
        
        [SerializeField] private float startingHealth;
        public float currentHealth { get; private set; }

        private void Awake()
        {
            currentHealth = startingHealth;
        }

        private void TakeDamage(float damage)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
            if (currentHealth > 0)
            {
                //player hurt
            }
            else
            {
                //player dead
            }
        }
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("damage");
                TakeDamage(10);
            }
        }
    }
}
