using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected int _maxAmmoMagazine;
    [SerializeField] protected float _delayShoot;
    [SerializeField] protected float _timeReload;
    private int _currentAmmoMagazine;
    private bool _canFire;

    protected virtual void Awake()
    {
        _canFire = true;
        _currentAmmoMagazine = _maxAmmoMagazine;
    }

    protected virtual void SpawnBullet(Transform spawnPoint) 
    {
        GameObject bullet = Instantiate(_bullet, spawnPoint.position, spawnPoint.rotation);

        DeegreaseBullet();
    }

    protected bool CanFire() => _canFire;

    private void DeegreaseBullet()
    {
        _currentAmmoMagazine--;
        if (_currentAmmoMagazine <= 0)
        {
            StartCoroutine(Reload());
        }
        else
        {
            StartCoroutine(DelayShoot());
        }
    }

    private IEnumerator Reload()
    {
        _canFire = false;
        yield return new WaitForSeconds(_timeReload);
        _currentAmmoMagazine = _maxAmmoMagazine;
        _canFire = true;
    }

    private IEnumerator DelayShoot()
    {
        _canFire = false;
        yield return new WaitForSeconds(_delayShoot);
        _canFire = true;
    }
}