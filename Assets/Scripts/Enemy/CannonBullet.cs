using UnityEngine;

namespace Enemy
{
    public class CannonBullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _speed;


        private void Start()
        {
            Transform playerTransform = FindObjectOfType<PlayerMove>().transform;
            Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
            _rigidbody.velocity = toPlayer * _speed;
        }
    }
}
