#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float _distanceToActivate = 20f;

    private bool _isActive = true;

    private Actovator _actovator;

    private void Start()
    {
        _actovator = FindObjectOfType<Actovator>();
        _actovator.ObjectsToActivate.Add(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        var distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (distance > _distanceToActivate + 2f) Deactivate();
        }
        else
        {
            if (distance < _distanceToActivate) Activate();
        }
    }

    private void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _actovator.ObjectsToActivate.Remove(this);
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActivate);
    }
    #endif
}