using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class HealthBar : MonoBehaviour
    {
        
        [SerializeField] private Health playerHealth;
        [SerializeField] private Image totalHealthBar;
        [SerializeField] private Image currentHealthBar;

        void Start()
        {
            totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
            //playerHealth.currentHealth -= 1;
        }

        // Update is called once per frame
        void Update()
        {
            currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     //totalHealthBar.fillAmount--;
            //    // TakeDamege(playerHealth.currentHealth);
            // }
        }
    }
}