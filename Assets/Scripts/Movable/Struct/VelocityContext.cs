using Unity.VisualScripting;
using UnityEngine;

namespace Movable.Struct
{
    public struct VelocityContext
    {
        public Vector2 Velocity;
        public float DeltaTime;
        public bool OnGround;

        public VelocityContext(Vector2 velocity, float deltaTime, bool onGround)
        {
            Velocity = velocity;
            DeltaTime = deltaTime;
            OnGround = onGround;
        }
    }
}