using UnityEngine;

namespace Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawn;

        [SerializeField] private float _bulletSpeed = 10f;
        [SerializeField] private float _shotPeriod = 0.2f;

        [SerializeField] private AudioSource _shotSound;
        [SerializeField] private GameObject _flash;


        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > _shotPeriod)
                if (Input.GetMouseButton(0))
                {
                    _timer = 0f;
                    Shot();
                }
        }

        public virtual void Shot()
        {
            var newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;

            _shotSound.Play();
            _flash.SetActive(true);

            Invoke("HideFlash", 0.15f);
        }

        private void HideFlash()
        {
            _flash.SetActive(false);
        }

        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public virtual void AddBullets(int numberOfBullets)
        {
        }
    }
}