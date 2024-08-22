using Guns;
using UnityEngine;

namespace Loot
{
    public class LootBullets : MonoBehaviour
    {
        [SerializeField] private int _gunIndex;
        [SerializeField] private int _numberOfBullets;

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.GetComponent<PlayerArmory>())
            {
                other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(_gunIndex, _numberOfBullets);
                Destroy(gameObject);
            }
        }
    }
}

