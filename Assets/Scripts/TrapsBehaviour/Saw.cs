using Character.Interfaces;
using UnityEngine;

namespace TrapsBehaviour
{
    [RequireComponent(typeof(Collider2D))]
    public class Saw : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.TakeDamage();
            }
        }
    }
}