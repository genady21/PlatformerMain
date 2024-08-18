using System.Collections.Generic;
using UnityEngine;

public class Actovator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectsToActivate;
    [SerializeField] private Transform _playerTransform;

    private void Update()
    {
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {
            ObjectsToActivate[i].CheckDistance(_playerTransform.position);
        }
    }
}
