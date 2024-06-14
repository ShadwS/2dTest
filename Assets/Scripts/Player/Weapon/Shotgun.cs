using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] protected Transform[] _spawnPoints;

    protected override void Awake() => base.Awake();

    protected virtual void Update()
    {
        if (Input.GetMouseButton(0) && CanFire())
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                SpawnBullet(spawnPoint);
            }
        }
    }
}