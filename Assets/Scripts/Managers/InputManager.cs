using Controllers;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private RespawnController<Character.Character> _respawnerController;

        public void Initialize(RespawnController<Character.Character> spawner)
        {
            _respawnerController = spawner;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                _respawnerController.Respawn();
        }
    }
}