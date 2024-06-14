using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerHealth Health => _health;

    [SerializeField] private PlayerHealth _health;
}