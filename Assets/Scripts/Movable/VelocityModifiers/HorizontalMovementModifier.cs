using Movable.Struct;
using Movable.VelocityModifiers.Interface;
using UnityEngine;

namespace Movable.VelocityModifiers
{
    public class HorizontalMovementModifier : IVelocityModifier
    {
        private readonly float _moveSpeed;
        private float _direction;

        public HorizontalMovementModifier(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }

        public void SetDirection(float direction)
        {
            _direction = Mathf.Clamp(direction, -1f, 1f);
        }

        public void Modify(ref VelocityContext context)
        {
            context.Velocity.x = _direction * _moveSpeed;
        }
    }
}