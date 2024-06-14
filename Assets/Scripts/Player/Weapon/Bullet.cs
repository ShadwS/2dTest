using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Rigidbody2D _rigidbody;

    private void Awake() => _rigidbody = gameObject.GetComponent<Rigidbody2D>();

    public void MoveForward() => _rigidbody.AddRelativeForce(Vector2.up * _speed);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(gameObject);
        }
    }
}