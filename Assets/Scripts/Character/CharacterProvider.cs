using Character.Interfaces;

namespace Character
{
    public class CharacterProvider : ICharacterProvider
    {
        public Character Character { get; private set; }
        
        public void SetCharacter(Character character)
        {
            Character = character;
        }
    }
}