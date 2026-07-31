using Character;
using Character.Interfaces;

namespace Controllers
{
    public class FallController
    {
        private readonly ICharacterProvider _characterProvider;
        private readonly RespawnController<Character.Character> _respawnCharacterController;
        private readonly float _threshold;
        
        public FallController(ICharacterProvider characterProvider, RespawnController<Character.Character> respawnCharacterController, float threshold)
        {
            _characterProvider = characterProvider;
            _respawnCharacterController = respawnCharacterController;
            _threshold = threshold;
        }

        public void Check()
        {
            if (_characterProvider.Character.transform.position.y <= _threshold)
                _respawnCharacterController.Respawn();
        }
    }
}