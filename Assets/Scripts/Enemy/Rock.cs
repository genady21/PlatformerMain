using UnityEngine;
using Random = UnityEngine.Random;

public class Rock : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotationSpeed=10f;
    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(_velocity,ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed), 
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed)
            );
    }
}
