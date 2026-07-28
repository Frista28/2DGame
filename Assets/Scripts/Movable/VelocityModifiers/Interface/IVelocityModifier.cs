using Movable.Struct;

namespace Movable.VelocityModifiers.Interface
{
    public interface IVelocityModifier
    {
        public void Modify(ref VelocityContext velocityContext);
    }
}