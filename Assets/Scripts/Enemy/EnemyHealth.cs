using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    private SpawnEnemy _spawner;

    public void SetSpawner(SpawnEnemy spawner) => _spawner = spawner;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Remove();
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    
    public void Remove()
    {
        _spawner.RemoveEnemy();
    }
}