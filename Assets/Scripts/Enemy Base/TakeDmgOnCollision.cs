using UnityEngine;

namespace Guns
{
    public class TakeDmgOnCollision : MonoBehaviour
    {
        [SerializeField] private EnemyHealh _enemyHealh;
        [SerializeField] private bool _dieOnAnyCollision;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.rigidbody)
            {
                if (collision.rigidbody.GetComponent<Bullet>())
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
