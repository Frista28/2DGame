using Character.Interfaces;

namespace Controllers
{
    public class DieCharacterController
    {
        private readonly ICharacterProvider _characterProvider;
        private readonly RespawnController<Character.Character> _respawnCharacterController;
        private readonly float _threshold;
        
        public DieCharacterController(ICharacterProvider characterProvider, RespawnController<Character.Character> respawnCharacterController, float threshold)
        {
            _characterProvider = characterProvider;
            _respawnCharacterController = respawnCharacterController;
            _threshold = threshold;
        }

        public void Check()
        {
            if (_characterProvider.Character.transform.position.y <= _threshold)
            {
                _respawnCharacterController.Respawn();
                return;
            }
            
            if (_characterProvider.Character.IsDead)
            {
                _respawnCharacterController.Respawn();
            }
        }
    }
}