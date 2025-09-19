using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpawnedObject
{
    public GameObject gameObject;
    public ObjectSpawner originSpawn;

    public SpawnedObject(GameObject gameObject, ObjectSpawner originSpawn)
    {
        this.gameObject = gameObject;
        this.originSpawn = originSpawn; 
    }
}

public class ObjectManager : MonoBehaviour
{
    public List<ObjectSpawner> enabledSpawns = new List<ObjectSpawner>();

    public List<SpawnedObject> spawnedObjects = new List<SpawnedObject>();

    public void spawnRandom(int amount)
    {
        for (int i = 0; i < amount; i++)
        {

            if (enabledSpawns.Count <= 0) { break; }

            // Get Random Spawner
            int randomSpawnerIndex = Random.Range(0, enabledSpawns.Count);
            ObjectSpawner randomSpawner = enabledSpawns[randomSpawnerIndex];

            // Spawn Random Object
            GameObject randomObject = randomSpawner.GetRandomObject();
            GameObject newObject = Instantiate(randomObject, randomSpawner.spawnLocation);

            // Add to list
            SpawnedObject newSpawned = new SpawnedObject(newObject, randomSpawner);
            spawnedObjects.Add(newSpawned);

            // Disable Spawn (later re-enable)
            enabledSpawns.Remove(randomSpawner);

        }
    }

    // Give it a spawned object that has been moved, and it will renable the spawn
    public void enableSpawnByObject(SpawnedObject spawnedObject)
    {
        if (!enabledSpawns.Contains(spawnedObject.originSpawn))
        {
            enabledSpawns.Add(spawnedObject.originSpawn);
        }
    }
}
