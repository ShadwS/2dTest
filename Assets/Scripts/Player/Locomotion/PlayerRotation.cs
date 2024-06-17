using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Start() => EndGame.GameOver += GameOver;

    private void Update()
    {
        Vector3 direction = Input.mousePosition;
        direction = _camera.ScreenToWorldPoint(direction) - gameObject.transform.position;
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    private void OnDestroy() => EndGame.GameOver -= GameOver;

    private void GameOver() => this.enabled = false;
}