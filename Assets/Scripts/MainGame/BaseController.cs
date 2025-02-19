using System;
using UnityEngine;

namespace MainGame
{
    public class BaseController : MonoBehaviour
    {
        protected Rigidbody2D _rigidbody;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        protected Vector2 movementDirection = Vector2.zero;
        public Vector2 MovementDirection{get{return movementDirection;}}
        
        protected Vector2 lookDirection = Vector2.zero;
        public Vector2 LookDirection{get{return lookDirection;}}

        [SerializeField] private int speed = 5;
        protected int Speed
        {
            get{return speed;}
            set => speed = value;
        }


        protected AnimationHandler animationHandler;


        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            animationHandler = GetComponent<AnimationHandler>();
        }

        protected virtual void Start()
        {
            
        }

        protected virtual void Update()
        {
            HandleAction();
        }

        protected virtual void FixedUpdate()
        {
            Movement(movementDirection);
        }

        protected virtual void HandleAction()
        {
            
        }

        private void Movement(Vector2 direction)
        {
            direction *= Speed;
            _rigidbody.velocity = direction;
            animationHandler.Move(direction);
        }

       
    }
}
