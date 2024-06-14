using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speed;

    private void Update() => Move();

    private void Move()
    {
        Vector2 direction = Vector2.up * Input.GetAxis("Vertical") + Vector2.right * Input.GetAxis("Horizontal");
        gameObject.transform.Translate(direction.normalized * _speed * Time.deltaTime);
    }
}