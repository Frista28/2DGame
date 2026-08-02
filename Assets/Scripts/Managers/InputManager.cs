using Controllers;
using UnityEngine;
using CharacterController = Controllers.CharacterController;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private RespawnController<Character.Character> _respawnerController;
        private CharacterController _characterController;

        public void Initialize(RespawnController<Character.Character> spawner, CharacterController characterController)
        {
            _respawnerController = spawner;
            _characterController = characterController;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                _respawnerController.Respawn();
            
            if(Input.GetKeyDown(KeyCode.Space))
                _characterController.Jump();
            
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            if (horizontalMove != 0)
                _characterController.Move(horizontalMove);
        }
    }
}