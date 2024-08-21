using UnityEngine;

namespace Player
{
    public class Follow : MonoBehaviour
    {
        [SerializeField] private Transform target;  
        [SerializeField] private float smoothSpeed = 0.125f;  
        [SerializeField] private Vector3 offset; 

        void LateUpdate()
        {
            Vector3 currentPosition = transform.position;
            
            Vector3 targetPosition = new Vector3(currentPosition.x, target.position.y + offset.y, currentPosition.z);
         
            Vector3 smoothedPosition = Vector3.Lerp(currentPosition, targetPosition, smoothSpeed);
            
            transform.position = smoothedPosition;
        }
    }
}