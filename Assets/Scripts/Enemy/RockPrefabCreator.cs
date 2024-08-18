using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] Spawns;
    
    [ContextMenu("Create")]
    public  void Create()
    {
        for (int i = 0; i < Spawns.Length; i++)
        {
            Instantiate(_prefab, Spawns[i].position, Spawns[i].rotation);
        }
    }
}
