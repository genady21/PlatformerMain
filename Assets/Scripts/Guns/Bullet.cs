using UnityEngine;

namespace Guns
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject _effectPrefab;

        private void Start()
        {
            Destroy(gameObject, 4f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Instantiate(_effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.GetComponent<TakeDmgOnTrigger>();
            if (enemy != null)
            {
                Instantiate(_effectPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
