using Checkers;
using Movable;
using Movable.Struct;
using Movable.VelocityModifiers;
using Movable.VelocityModifiers.Interface;
using Spawners.Interfaces;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private float _gravity = 9.81f;
        
        [SerializeField] private float _moveSpeed = 9f;
        [SerializeField] private float _jumpForce = 8f;
        
        private HorizontalMovementModifier _horizontalMovementModifier;
        private JumpModifier _jumpModifier;
        
        [SerializeField] private Vector2 _groundCheckVector = Vector2.down;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckDistance = 0.1f;
        
        private CapsuleSurfaceChecker _groundChecker;
        
        private Rigidbody2D _rigidbody;

        private VelocityContext _velocityContext;

        private ModifierComponentsMover _mover;

        public void Move(float direction)
        {
            _horizontalMovementModifier.SetDirection(direction);
        }

        public void Jump()
        {
            if(_velocityContext.OnGround)
                _jumpModifier.RequestJump();
        }
        
        private void Awake()
        {
            _velocityContext = new VelocityContext(Vector2.zero, Time.fixedDeltaTime, false);
            
            _rigidbody = GetComponent<Rigidbody2D>();

            _horizontalMovementModifier = new HorizontalMovementModifier(_moveSpeed);
            _jumpModifier = new JumpModifier(_jumpForce);
            
            IVelocityModifier gravityModifier = new GravityModifier(_gravity);

            _mover = new ModifierComponentsMover(_rigidbody);
            _mover.AddModifier(_horizontalMovementModifier);
            _mover.AddModifier(gravityModifier);
            _mover.AddModifier(_jumpModifier);
            
            CapsuleCollider2D capsuleCollider = GetComponent<CapsuleCollider2D>();
            _groundChecker = new CapsuleSurfaceChecker(_groundLayer, capsuleCollider, _groundCheckVector, _groundCheckDistance);
        }

        private void Update()
        {
            if(Input.GetButtonDown("Jump"))
                Jump();
            
            Move(Input.GetAxisRaw("Horizontal"));
        }

        private void FixedUpdate()
        {
            _velocityContext.Velocity = _rigidbody.velocity;
            _velocityContext.DeltaTime = Time.fixedDeltaTime;
            _velocityContext.OnGround = IsGrounded();
            
            _mover.Move(ref _velocityContext);
        }

        private bool IsGrounded() => _groundChecker.IsTouching();
    }
}