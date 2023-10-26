using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiator : MonoBehaviour
{
    [SerializeField] private EnemyBheavior enemyPrefab;
    [SerializeField] private float spawnTimeOffset;
    [SerializeField] private float spawnAreaSize;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnTimeOffset);
    }

    private void SpawnEnemy()
    {
        Vector2 spawnArea = Random.insideUnitCircle * spawnAreaSize;
        Vector3 spawnPosition = new Vector3(spawnArea.x, enemyPrefab.transform.position.y, spawnArea.y);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, spawnAreaSize);
    }
}
