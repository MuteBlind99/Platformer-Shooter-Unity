using UnityEngine;

namespace Script.EnemyScript
{
    public class EnemySideways : MonoBehaviour
    {
        [SerializeField] private float damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
               //collision.GetComponent<Health>().TakeDamage(damage);
               collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}