using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectListSO spawnables;
    public Transform spawnLocation;

    public void Start()
    {
        spawnLocation = gameObject.transform;
    }

    public GameObject GetRandomObject()
    {
        int randomSpawnableIndex = Random.Range(0, spawnables.list.Count);
        return spawnables.list[randomSpawnableIndex];
    }
}
