using System;
using UnityEngine;

public class MakeDmgOnTrigger : MonoBehaviour
{
    [SerializeField] private int _dmgValue=1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                other.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(_dmgValue);
            }
        }
    }
}
