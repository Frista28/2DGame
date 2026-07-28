using Movable.Struct;
using Movable.VelocityModifiers.Interface;
using UnityEngine;

namespace Movable.VelocityModifiers
{
    public class GravityModifier : IVelocityModifier
    {
        private readonly float _gravity;

        public GravityModifier(float gravity)
        {
            _gravity = gravity;
        }
        
        public void Modify(ref VelocityContext velocityContext)
        {
            // if(!velocityContext.OnGround)
            //     velocityContext.Velocity.y -= _gravity * velocityContext.DeltaTime;
            // else if (velocityContext.Velocity.y < 0)
            //     velocityContext.Velocity.y = -0.1f;
            velocityContext.Velocity.y -= _gravity * velocityContext.DeltaTime;
        }
    }
}