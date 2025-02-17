using UnityEngine;

namespace FlapPlane
{
    public class Player : MonoBehaviour
    {
        Animator animator = null;
        Rigidbody2D _rigidbody = null;

        public float flapForce = 6f;
        public float forwardSpeed = 3f;
        public bool isDead = false;
        float deathCooldown = 0f;
    
        bool isFlap = false;

        public bool godMode = false;
    
        GameManager gameManager = null;

        void Start()
        {
            gameManager = GameManager.Instance;
        
            animator = transform.GetComponentInChildren<Animator>();
            _rigidbody = transform.GetComponent<Rigidbody2D>();

            if (animator == null)
            {
                Debug.LogError("Not Founded Animator");
            }

            if (_rigidbody == null)
            {
                Debug.LogError("Not Founded Rigidbody");
            }
        }

        void Update()
        {
            if (isDead)
            {
                if (deathCooldown <= 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    {
                        // 게임 재시작
                        gameManager.RestartGame();
                    }
                    
                    else if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        gameManager.GameOut();
                    }
                }
                else
                {
                    deathCooldown -= Time.deltaTime;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) ||Input.GetMouseButtonDown(0))
                {
                    isFlap = true;
                }
            }
        }

        public void FixedUpdate()
        {
            if (isDead)
                return;
        
            Vector3 velocity = _rigidbody.velocity;
            velocity.x = forwardSpeed;

            if (isFlap)
            {
                velocity.y += flapForce;
                isFlap = false;
            }
        
            _rigidbody.velocity = velocity;
        
            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
            float lerpAngle = Mathf.Lerp(_rigidbody.velocity.y, angle, Time.deltaTime * 5f);
            transform.rotation = Quaternion.Euler(0, 0, lerpAngle);
        }
    
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (godMode)
                return;
        
            if (isDead)
                return;

            animator.SetInteger("IsDie", 1);
            isDead = true;
            deathCooldown = 1f;
            gameManager.GameOver();
        }
    }
}