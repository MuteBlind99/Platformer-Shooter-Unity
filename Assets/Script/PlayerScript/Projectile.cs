using System;
using UnityEngine;


namespace Script
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        private float _direction;
        private bool _hit;
        private float _lifetime;

        private Animator _animator;
        private Animation _animation;
        private BoxCollider2D _boxCollider;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_hit)
            {
                //Deactivate();
                return;
            }

            float movementSpeed = speed * Time.deltaTime * _direction;
            transform.Translate(movementSpeed, 0, 0);
            _lifetime += Time.deltaTime;
            if (_lifetime > 2) gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _hit = true;
            _boxCollider.enabled = false;
            //_animator.SetTrigger("explode");
            Explode();

            //Debug.Log(_hit);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag=="Enemy")
            {
                other.GetComponent<Health>().TakeDamage(1);
            }
        }

        public void SetDirection(float direction)
        {
            _lifetime = 0;
            _direction = direction;
            gameObject.SetActive(true);
            _hit = false;
            _boxCollider.enabled = true;

            float localScaleX = transform.localScale.x;

            if (Mathf.Sign(localScaleX) != direction)
            {
                localScaleX = -localScaleX;
            }

            transform.localScale = new Vector2(localScaleX, transform.localScale.y);
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void Explode()
        {
            _animator.SetTrigger("explode");
        }
    }
}