using Spawners.Interfaces;
using UnityEngine;

namespace Spawners
{
    public class SpawnerInPoint : IGameObjectSpawner
    {
        private readonly Transform _spawnPointTransform;
    
        public SpawnerInPoint(Transform spawnPointTransform)
        {
            _spawnPointTransform = spawnPointTransform;
        }

        public T Spawn<T>(T prefab) where T : MonoBehaviour
        {
            return Object.Instantiate(prefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }
    }
}
