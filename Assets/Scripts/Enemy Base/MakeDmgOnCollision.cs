using UnityEngine;

public class MakeDmgOnCollision : MonoBehaviour
{
    [SerializeField] private int _dmgValue;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerHealth>())
            {
                collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_dmgValue);
            }
        }
    }
}
