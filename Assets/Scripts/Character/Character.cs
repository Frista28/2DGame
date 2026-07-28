using Movable;
using Movable.Struct;
using Movable.VelocityModifiers;
using Movable.VelocityModifiers.Interface;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float _gravity = 9.81f;
        [SerializeField] private float _moveSpeed = 9f;
        [SerializeField] private float _jumpForce = 8f;
        
        [SerializeField] private Transform _groundCheckTransform;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckDistance = 0.1f;
        
        private Rigidbody2D _rigidbody;

        private VelocityContext _velocityContext;

        private HorizontalMovementModifier _horizontalMovementModifier;
        private JumpModifier _jumpModifier;

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

        private bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _groundLayer);
            return hit.collider != null;
        }
    }
}