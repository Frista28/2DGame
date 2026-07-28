using System.Collections.Generic;
using Movable.Struct;
using Movable.VelocityModifiers.Interface;
using UnityEngine;

namespace Movable
{
    public class ModifierComponentsMover
    {
        private readonly List<IVelocityModifier> _modifiers = new();
        private readonly Rigidbody2D _rigidbody;

        public ModifierComponentsMover(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }
        
        public void AddModifier(IVelocityModifier modifier) => _modifiers.Add(modifier);

        public void Move(ref VelocityContext velocityContext)
        {
            foreach (var mod in _modifiers)
            {
                mod.Modify(ref velocityContext);
            }
            
            _rigidbody.velocity = velocityContext.Velocity;
        }
    }
}
