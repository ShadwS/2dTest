using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public Transform Player => _player;

    [SerializeField] private Transform _player;
    [SerializeField] private GameObject[] _enemies;
    [Space]
    [Header("Spawn Settings")]
    [SerializeField] private Transform[] _spawnPoints;//0-left, 1-right, 2-up, 3-bottom
    [SerializeField] private int _enemySpawnCount;
    [SerializeField] private int _enemySpawnDelay;
    [SerializeField] private int _enemySpawnIncrease;
    private int _maxEnemySpawnCount = 0;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {;
        _maxEnemySpawnCount += _enemySpawnIncrease;
        _enemySpawnCount = _maxEnemySpawnCount;
        for (int i = 0; i < _maxEnemySpawnCount; i++)
        {
            Vector2 spawnPoint = Vector2.zero;
            if(Random.Range(0,2) == 0)//left or rigth
            {
                spawnPoint.x = _spawnPoints[Random.Range(0,2)].position.x;
            }
            else//up or bottom
            {
                spawnPoint.y = _spawnPoints[Random.Range(2, 4)].position.y;
            }
            if(spawnPoint.x == 0)//up or bottom
            {
                spawnPoint.y = Random.Range(_spawnPoints[3].position.y, _spawnPoints[2].position.y);
            }
            else//left or rigth
            {
                spawnPoint.x = Random.Range(_spawnPoints[0].position.x, _spawnPoints[1].position.x);
            }
            Instantiate(_enemies[Random.Range(0, _enemies.Length)], spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(_enemySpawnDelay);
        }
    }
}