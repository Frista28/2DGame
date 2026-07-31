using System;
using Character;
using Character.Interfaces;
using Controllers;
using Spawners;
using Spawners.Interfaces;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        
        [SerializeField] private Character.Character _characterPrefab;
        [SerializeField] private Transform _characterSpawnPoint;
        [SerializeField] private float _fallThreshold = -3f;
        
        private RespawnController<Character.Character> _respawnCharacterController;
        private FallController _fallController;

        private ICharacterProvider _characterProvider;

        private void Awake()
        {
            IGameObjectSpawner spawner = new SpawnerInPoint(_characterSpawnPoint);
            Character.Character character = spawner.Spawn(_characterPrefab);

            _characterProvider = new CharacterProvider();
            _characterProvider.SetCharacter(character);
            
            _respawnCharacterController = new RespawnController<Character.Character>(spawner, _characterPrefab, _characterProvider);
            _fallController = new FallController(_characterProvider, _respawnCharacterController, _fallThreshold);
        }

        private void Start()
        {
            _inputManager.Initialize(_respawnCharacterController);
        }

        private void Update()
        {
            _fallController.Check();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(
                new Vector3(-100f, _fallThreshold, 0f),
                new Vector3(100f, _fallThreshold, 0f)
                );
        }
    }
}