using Character.Interfaces;

namespace Controllers
{
    public class CharacterController
    {
        private readonly ICharacterProvider _characterProvider;
        
        public CharacterController (ICharacterProvider characterProvider)
        {
            _characterProvider = characterProvider;
        }

        public void Move(float velocity)
        {
            _characterProvider.Character?.Move(velocity);
        }

        public void Jump()
        {
            _characterProvider.Character?.Jump();
        }
    }
}