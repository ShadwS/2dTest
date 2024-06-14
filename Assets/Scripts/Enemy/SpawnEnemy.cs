using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform Player => _player;

    [SerializeField] private Transform _player;
    [SerializeField] private GameObject[] _enemies;
    [Space]
    [Header("Spawn Settings")]
    [SerializeField] private int _enemySpawnCount;
    [SerializeField] private int _enemySpawnDelay;
    [SerializeField] private int _enemySpawnIncrease;
    [Space]
    [Header("Wave Settings")]
    [SerializeField] private int _currentWave;
}