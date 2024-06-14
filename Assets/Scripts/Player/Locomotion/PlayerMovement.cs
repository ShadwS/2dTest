using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private int _speed;

    private void Update() => Move();

    private void Move()
    {
        Vector2 direction = Vector2.up * Input.GetAxis("Vertical") + Vector2.right * Input.GetAxis("Horizontal");
        _playerBody.Translate(direction.normalized * _speed * Time.deltaTime);
    }
}