using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private Camera _camera;
    [SerializeField] private int _speed;
    private Vector2 _leftBottom;
    private Vector2 _rightUp;

    private void Awake()
    {
        _leftBottom = _camera.ViewportToWorldPoint(Vector2.zero);
        _rightUp = _camera.ViewportToWorldPoint(Vector2.one);
    }

    private void Update() => Move();

    private void Move()
    {
        Vector2 direction = Vector2.up * Input.GetAxis("Vertical") + Vector2.right * Input.GetAxis("Horizontal");
        _playerBody.Translate(direction.normalized * _speed * Time.deltaTime);

        _playerBody.position = new Vector2(Mathf.Clamp(_playerBody.position.x, _leftBottom.x + _collider.bounds.size.x, 
            _rightUp.x - _collider.bounds.size.x),
            Mathf.Clamp(_playerBody.position.y, _leftBottom.y + _collider.bounds.size.y / 2,
            _rightUp.y - _collider.bounds.size.y / 2));
    }
}