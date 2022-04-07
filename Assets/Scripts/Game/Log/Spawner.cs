using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private SpawnManagerScriptableObject    spawnManagerValues;
    [SerializeField]
    private float                           chanceOfSpawn;
    [SerializeField]
    private GameObject                      entityToSpawn;

    private int instanceNumber = 0;

    private List<int> usedSpawnPointIndexes = new List<int>();

    private void Awake()
    {
        SpawnEntities();
    }

    private int SelectRandomSpawnIndex()
    {
        int randomSpawnIndex;
        
        // Checks if there is already a knife spawned at the current position and cycles to find an empty one
        do
        {
            randomSpawnIndex = Random.Range(0, spawnManagerValues.spawnPoints.Length);
        } while (usedSpawnPointIndexes.Contains(randomSpawnIndex));

        return randomSpawnIndex;
    }

    private void SpawnEntity(int randomSpawnIndex)
    {
        // Spawns entity, places and rotates it properly and names it
        GameObject currentEntity = Instantiate(entityToSpawn);
        currentEntity.transform.SetParent(transform);
        currentEntity.transform.localPosition = spawnManagerValues.spawnPoints[randomSpawnIndex];
        currentEntity.transform.localRotation = spawnManagerValues.spawnRotations[randomSpawnIndex];
        currentEntity.name = spawnManagerValues.prefabName + instanceNumber;
    }

    private void SpawnEntities()
    {
        // Creates entities according to Scriptable Object with given chance
        for (int i = 0; i < spawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            if (Random.value < chanceOfSpawn)
            {
                int randomSpawnIndex = SelectRandomSpawnIndex();
                usedSpawnPointIndexes.Add(randomSpawnIndex); // Include current index to the "Already used" list

                SpawnEntity(randomSpawnIndex);

                instanceNumber++;
            }
        }
    }
}
