using UnityEngine;

namespace Spawners.Interfaces
{
    public interface IGameObjectSpawner
    {
        public T Spawn<T>(T prefab) where T : MonoBehaviour;
    }
}