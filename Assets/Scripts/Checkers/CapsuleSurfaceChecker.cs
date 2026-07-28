using UnityEngine;

namespace Checkers
{
    public class CapsuleSurfaceChecker
    {
        private LayerMask _layerMask;
        private CapsuleCollider2D _capsuleCollider;
        private Vector2 _direction;
        private float _distanceToCheck;

        public CapsuleSurfaceChecker(LayerMask layerMask, CapsuleCollider2D capsuleCollider, Vector2 direction,
            float distanceToCheck)
        {
            _layerMask = layerMask;
            _capsuleCollider = capsuleCollider;
            _direction = direction;
            _distanceToCheck = distanceToCheck;
        }
        
        public bool IsTouching()
        {
            RaycastHit2D hit = Physics2D.CapsuleCast(
                _capsuleCollider.bounds.center, 
                _capsuleCollider.size, 
                _capsuleCollider.direction, 
                0, 
                _direction, 
                _distanceToCheck, 
                _layerMask);
            
            return hit.collider != null;
        }
    }
}