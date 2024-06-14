using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth Health => _health;

    [SerializeField] private EnemyHealth _health;
    [SerializeField] private EnemyMovement _movement;
}