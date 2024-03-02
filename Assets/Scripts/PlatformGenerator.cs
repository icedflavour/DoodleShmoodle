using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] PlatformPrefabs;
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private float ShiftDistance;
    [SerializeField] private float SpawnDistance;
    [SerializeField] private float MinX, MaxX;
    [SerializeField] private int ChunkSize;
    [SerializeField] private Transform PlayerTransform;
    private Transform _lastGeneratorPoint;
    private Transform _spawnPoint;

    private void Start()
    {
        _lastGeneratorPoint = transform;
        _spawnPoint = _lastGeneratorPoint;
        
        GenerateChunk();
    }

    private void FixedUpdate() 
    {
        if (_lastGeneratorPoint.position.y - PlayerTransform.position.y < ShiftDistance) 
        {
            GenerateChunk();
        }
    }

    private void GenerateChunk()
    {
        for (int platformNumber = 0; platformNumber < ChunkSize; platformNumber++)
        {   
            var SpawnRandomizer = Random.Range(0,2);
            var ObjectToSpawn = PlatformPrefabs[Random.Range(0,PlatformPrefabs.Length)];
            _spawnPoint.position = new Vector3(Random.Range(MinX, MaxX), _spawnPoint.position.y, _spawnPoint.position.z);
            Instantiate(ObjectToSpawn, _spawnPoint.position, Quaternion.identity);
            Debug.Log(SpawnRandomizer);
            if (SpawnRandomizer % 2 == 0)
            {
                Instantiate(CoinPrefab, _spawnPoint.position + new Vector3(0,1,0), Quaternion.identity);
            }
            _spawnPoint.position = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y + SpawnDistance, _spawnPoint.position.z);

            if (platformNumber == 10)
            {
               _lastGeneratorPoint = _spawnPoint;
            }
        }
    }
}
