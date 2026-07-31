using System.Collections;
using UnityEngine;

namespace TrapsBehaviour
{
    public class PointsPatrol : MonoBehaviour
    {
        [SerializeField] private Transform _transformPatroling;
        [SerializeField] private Transform _startPointTransform;
        [SerializeField] private Transform _endPointTransform;
        [SerializeField] private float _patrolSpeed;

        private void Awake() => StartCoroutine(PatrolProcess());
        
        private IEnumerator PatrolProcess()
        {
            Vector3 startPosition = _startPointTransform.position;
            Vector3 endPosition = _endPointTransform.position;
            
            while (true)
            {
                float distance = Vector3.Distance(startPosition, endPosition);
                float duration = distance / _patrolSpeed;
        
                float progress = 0f;
        
                while (progress < duration)
                {
                    float t = progress / duration;
                    
                    _transformPatroling.position = Vector3.Lerp(startPosition, endPosition, t);
            
                    progress += Time.deltaTime;
                    yield return null;
                }
                
                _transformPatroling.position = endPosition;
        
                (startPosition, endPosition) = (endPosition, startPosition);
            }
        }
    }
}