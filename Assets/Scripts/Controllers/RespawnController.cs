using Character.Interfaces;
using Spawners.Interfaces;
using UnityEngine;

namespace Controllers
{
    public class RespawnController<T> where T : MonoBehaviour
    {
        private readonly IGameObjectSpawner _spawner;
        private readonly T _prefab;
        private readonly ICharacterProvider _characterProvider;

        public RespawnController (IGameObjectSpawner spawner, T prefab, ICharacterProvider characterProvider)
        {
            _spawner = spawner;
            _prefab = prefab;
            _characterProvider = characterProvider;
        }

        public void Respawn()
        {
            if (_characterProvider.Character != null)
                Object.Destroy(_characterProvider.Character.gameObject);
            
            T newCharacter = _spawner.Spawn(_prefab);
            
            if (newCharacter is Character.Character character)
            {
                _characterProvider.SetCharacter(character);
            }
        }
    }
}