using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        Vector3 difference = gameObject.transform.position - _camera.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.LookAt(difference, Vector3.forward);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z);
    }
}