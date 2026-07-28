using Movable.Struct;
using Movable.VelocityModifiers.Interface;

namespace Movable.VelocityModifiers
{
    public class JumpModifier : IVelocityModifier
    {
        private readonly float _jumpForce;
        private bool _isJumpRequested;

        public JumpModifier(float jumpForce)
        {
            _jumpForce = jumpForce;
        }
        
        public void RequestJump() => _isJumpRequested = true;

        public void Modify(ref VelocityContext velocityContext)
        {
            if (_isJumpRequested && velocityContext.OnGround)
            {
                _isJumpRequested = false;
                velocityContext.Velocity.y += _jumpForce;
            }
        }
    }
}