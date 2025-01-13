using UnityEngine;

namespace Script.EnemyScript
{
    public class Enemy_Sideway : MonoBehaviour
    {
        [SerializeField] private float damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}