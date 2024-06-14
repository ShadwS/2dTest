using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Rigidbody2D _rigidbody;
    private int _damage;

    private void Awake() => _rigidbody = gameObject.GetComponent<Rigidbody2D>();

    public void MoveForward() => _rigidbody.AddRelativeForce(Vector2.up * _speed);
    public void SetDamage(int value) => _damage = value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}