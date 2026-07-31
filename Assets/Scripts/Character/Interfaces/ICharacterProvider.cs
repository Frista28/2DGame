using UnityEngine;

namespace Character.Interfaces
{
    public interface ICharacterProvider
    {
        Character Character { get; }
        public void SetCharacter(Character character);
    }
}