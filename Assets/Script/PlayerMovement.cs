using UnityEngine;

namespace Script
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask wallLayer;
        private Rigidbody2D _rb;
        private Animator _animator;
        private Collider2D _collider;
        private float _wallJumpCoolDown;
        private float _horizontalInput;
        private bool _canAttack;
        // private int _jumpcount = 0;


        [SerializeField] private float speed = 10f;
        [SerializeField] private float jump = 10f;

        public bool CanAttack1 => _canAttack;

        //Grabb references for Rigidbody and Animator form object
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            _canAttack = _horizontalInput == 0 && IsGrounded() && !OnWall();
            Debug.Log("Can attack"+_canAttack);
            
            _horizontalInput = Input.GetAxis("Horizontal");


            //Flip player horizontal Right/Left
            if (_horizontalInput > 0.01f)
            {
                transform.localScale = Vector2.one * 7;
            }
            else if (_horizontalInput < -0.01f)
            {
                transform.localScale = new Vector2(-7, 7);
            }


            // if (Input.GetKeyDown(KeyCode.Space) && _jumpcount < 2)
            // {
            //     Jump();
            // }

            //Set animator parameters
            _animator.SetBool("run", _horizontalInput != 0);
            _animator.SetBool("grounded", IsGrounded());

            //Wall jump logic
            if (_wallJumpCoolDown > 0.2f)
            {
                _rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rb.linearVelocity.y);

                if (OnWall() && IsGrounded())
                {
                    _rb.gravityScale = 0f;
                    _rb.linearVelocity = Vector2.zero;
                }

                else
                    _rb.gravityScale = 1.5f;

                //Player press Space to jump
                if (Input.GetKeyDown(KeyCode.Space))
                    Jump();
            }
            else
            {
                _wallJumpCoolDown += Time.deltaTime;
            }

            //print(onWall());
        }

        private void Jump()
        {
            if (IsGrounded())
            {
                _rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

                _animator.SetTrigger("jump");
            }
            else if (OnWall() && !IsGrounded())
            {
                if (_horizontalInput == 0)
                {
                    _rb.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                    transform.localScale = new Vector3(Mathf.Sign(transform.localScale.x), transform.localScale.y,
                        transform.localScale.z);
                }
                else
                    _rb.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 6, 12);

                _wallJumpCoolDown = 0;
            }
        }

        //Player touch the ground
        private bool IsGrounded()
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f,
                Vector2.down, 0.1f, groundLayer);
            return raycastHit.collider != null;
        }

        //Player touch a wall
        private bool OnWall()
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f,
                new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
            return raycastHit.collider != null;
        }
        //Player can hit only when is standing(not moving)
        public void CanAttack()
        {
            //return _horizontalInput == 0 && IsGrounded() && OnWall();
        }
    }
}