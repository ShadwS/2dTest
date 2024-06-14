using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Transform _player;
    private Transform _parent;

    private void Start()
    {
        _parent = gameObject.transform.parent;
    }

    private void FixedUpdate()
    {
        _parent.position = Vector2.MoveTowards(_parent.position, _player.position,
                _speed * Time.fixedDeltaTime);
    }

    public void SetPlayer(Player player) => _player = player.gameObject.transform;
}