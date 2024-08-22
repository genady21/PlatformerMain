using UnityEngine;

namespace Guns
{
    public class TakeDmgOnTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyHealh _enemyHealh;
        [SerializeField] private bool _dieOnAnyCollision;

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody)
            {
                if (other.attachedRigidbody.GetComponent<Bullet>())
                {
                    _enemyHealh.TakeDamage(1);
                }
            }

            if (_dieOnAnyCollision)
            {
                _enemyHealh.TakeDamage(10000);
            }
        }
    }
}
