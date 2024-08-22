using UnityEngine;

namespace Enemy
{
    public class CannonBulletCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawn;
        
        public void Create()
        {
            Instantiate(_bulletPrefab, _spawn.position, Quaternion.identity);
        }
    }
}
 