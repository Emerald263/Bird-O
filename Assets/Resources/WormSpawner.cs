using System;
using UnityEngine;
using Random = UnityEngine.Random;
public class WormSpawner : MonoBehaviour
{
    [Header("Spawner settings")]
    
    public Transform Player;
    public GameObject[] enemyPrefabs;

    public float spawnInterval = 2f;
    public float spawnRadius = 12f;
    public float timer = 0f;


    private void Update()
    {
        if (Player == null) return;
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    } 
     void SpawnEnemy()
    {
        GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        
        Vector2 spawnPos =(Vector2)Player.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemy, spawnPos, Quaternion.identity);

    }
}
