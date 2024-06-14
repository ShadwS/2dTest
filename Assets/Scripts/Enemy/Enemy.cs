using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth Health => _health;
    public EnemyMovement Movement => _movement;

    [SerializeField] private EnemyHealth _health;
    [SerializeField] private EnemyMovement _movement;

    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _health.Remove();
            player.Health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}