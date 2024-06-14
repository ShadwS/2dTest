using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _enemies;
    [Space]
    [Header("Spawn Settings")]
    [SerializeField] private Transform[] _spawnPoints;//0-left, 1-right, 2-up, 3-bottom
    [SerializeField] private int _enemySpawnCount;
    [SerializeField] private float _enemySpawnDelay;
    [SerializeField] private int _enemySpawnIncrease;
    private int _maxEnemySpawnCount = 0;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    public void RemoveEnemy()
    {
        _enemySpawnCount--;
        if (_enemySpawnCount <= 0)
        {
            StartCoroutine(Spawner());
        }
    }

    private IEnumerator Spawner()
    {
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
            if (spawnPoint.x == 0)//left or rigth
            {
                spawnPoint.x = Random.Range(_spawnPoints[3].position.x, _spawnPoints[2].position.x);
            }
            else//up or bottom
            {
                spawnPoint.y = Random.Range(_spawnPoints[0].position.y, _spawnPoints[1].position.y);
            }
            GameObject newEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)], spawnPoint, Quaternion.identity);
            Enemy enemy = newEnemy.GetComponent<Enemy>();
            enemy.Movement.SetPlayer(_player);
            enemy.Health.SetSpawner(this);
            yield return new WaitForSeconds(_enemySpawnDelay);
        }
    }
}