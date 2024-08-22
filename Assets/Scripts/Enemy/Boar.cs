using UnityEngine;

namespace Enemy
{
    public class Boar : MonoBehaviour
    {
        [SerializeField] private float _attackPeriod;
        [SerializeField] private Animator _animator;
        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > _attackPeriod)
            {
                _timer = 0;
                _animator.SetTrigger("Attack");
            }
        }
    }
}
