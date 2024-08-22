using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
   public enum Direction
   {
      Left,
      Right,
   }

   public class Walker : MonoBehaviour
   {
      [SerializeField] private Transform _leftTarget;
      [SerializeField] private Transform _rightTarget;

      [SerializeField] private float _speed;

      [SerializeField] private float _stopTime;

      [SerializeField] private Direction _currentDirection;

      private bool _isStoped;

      public UnityEvent eventOnLeftTarget;
      public UnityEvent eventOnRightTarget;

      [SerializeField] private Transform _rayStart;

      private void Start()
      {
         _leftTarget.parent = null;
         _rightTarget.parent = null;
      }

      private void Update()
      {
         if (_isStoped)
         {
            return;
         }

         if (_currentDirection == Direction.Left)
         {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0f, 0f);
            if (transform.position.x < _leftTarget.position.x)
            {
               _currentDirection = Direction.Right;
               _isStoped = true;
               Invoke("ContinueWalk", _stopTime);
               eventOnLeftTarget.Invoke();
            }
         }
         else
         {
            transform.position += new Vector3(Time.deltaTime * _speed, 0f, 0f);
            if (transform.position.x > _rightTarget.position.x)
            {
               _currentDirection = Direction.Left;
               _isStoped = true;
               Invoke("ContinueWalk", _stopTime);
               eventOnRightTarget.Invoke();
            }
         }

         RaycastHit hit;
         if (Physics.Raycast(_rayStart.position, Vector3.down, out hit))
         {
            transform.position = hit.point;
         }
      }

      private void ContinueWalk()
      {
         _isStoped = false;
      }
   }
}
