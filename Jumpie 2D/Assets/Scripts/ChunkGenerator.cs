using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public GameObject[] chunkPrefabs; 
    public Transform playerTransform; 
    private GameObject lastSpawnedChunk, chunkToDelete;
    private Transform nextSpawnPosition;

    // How far the player needs to move upwards to trigger the next chunk spawn
    public float spawnDistanceThreshold = 10f;
    public float deleteDistanceThreshold = 20f;


    private List<GameObject> activeChunks = new List<GameObject>();

    void Awake()
    {

        GameObject initialChunk = Instantiate(GetRandomChunkPrefab(), Vector3.zero, Quaternion.identity);
        playerTransform.position = initialChunk.transform.Find("PlayerStartPos").position;
        nextSpawnPosition = initialChunk.transform.Find("NextSpawnPos");
        activeChunks.Add(initialChunk);

    }

    void Update()
    {
        
        if (playerTransform.position.y > nextSpawnPosition.position.y - spawnDistanceThreshold)
        {
            SpawnNextChunk();
        }

        DeleteOffScreenChunks();
    }

    void SpawnNextChunk()
    {

        
        GameObject newChunk = Instantiate(GetRandomChunkPrefab(), nextSpawnPosition.position, Quaternion.identity);

        
        nextSpawnPosition = newChunk.transform.Find("NextSpawnPos");

        
        activeChunks.Add(newChunk);
    }


    GameObject GetRandomChunkPrefab()
    {
        // Return a random chunk prefab from the array
        int randomIndex = Random.Range(0, chunkPrefabs.Length);
        return chunkPrefabs[randomIndex];
    }


    void DeleteOffScreenChunks()
    {
        for (int i = activeChunks.Count - 1; i >= 0; i--)
        {
            
            if (playerTransform.position.y - activeChunks[i].transform.position.y > deleteDistanceThreshold)
            {
                
                Destroy(activeChunks[i]);
                activeChunks.RemoveAt(i);
            }
        }
    }

}
