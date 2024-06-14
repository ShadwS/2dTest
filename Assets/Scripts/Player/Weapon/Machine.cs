using UnityEngine;

public class Machine : Weapon
{
    [SerializeField] private Transform _spawnPoint;

    protected override void Awake() => base.Awake();

    private void Update()
    {
        if(Input.GetMouseButton(0) && CanFire())
        {
            SpawnBullet(_spawnPoint);
        }
    }
}