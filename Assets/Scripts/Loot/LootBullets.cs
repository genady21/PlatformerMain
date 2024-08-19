using Guns;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] private int _gunIndex;
    [SerializeField] private int _numberOfBullets;
    [SerializeField] private AudioSource _audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerArmory>())
        {
            _audioSource.Play();
            other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(_gunIndex,_numberOfBullets);
            Destroy(gameObject);
        }
    }
}
