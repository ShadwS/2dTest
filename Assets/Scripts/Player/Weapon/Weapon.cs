using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _reloadImage;
    [SerializeField] private Text _textAmmo;

    [Space]
    [Header("Seapon settings")]
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected int _maxAmmoMagazine;
    [SerializeField] protected float _delayShoot;
    [SerializeField] protected float _timeReload;
    [SerializeField] protected int _damage;
    private int _currentAmmoMagazine;
    private bool _canFire;
    private float _time = 0;

    protected virtual void Awake()
    {
        _canFire = true;
        _currentAmmoMagazine = _maxAmmoMagazine;
        _reloadImage.color = new Color(1, 1, 1, 0);
        _reloadImage.fillAmount = 0;
    }

    private void OnEnable()
    {
        _textAmmo.text = $"{_currentAmmoMagazine} / {_maxAmmoMagazine}";
        if (_time <= 0)
        {
            _canFire = true;
        }
        else
        {
            StartCoroutine(Wait());
        }
    }

    private void OnDisable()
    {
        _reloadImage.fillAmount = 0;
        _reloadImage.color = new Color(1, 1, 1, 0);
    }

    public bool CanFire() => _canFire;

    protected virtual void SpawnBullet(Transform spawnPoint) 
    {
        GameObject newBullet = Instantiate(_bullet, spawnPoint.position, spawnPoint.rotation);
        Bullet bullet = newBullet.GetComponent<Bullet>();
        bullet.MoveForward();
        bullet.SetDamage(_damage);
        DeegreaseBullet();
    }

    private void DeegreaseBullet()
    {
        _currentAmmoMagazine--;
        _textAmmo.text = $"{_currentAmmoMagazine} / {_maxAmmoMagazine}";
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
        _reloadImage.fillAmount = 0;
        _reloadImage.color = new Color(1, 1, 1, 1);
        _canFire = false;
        _time = _timeReload;
        while (_time > 0)
        {
            yield return new WaitForSeconds(0.05f);
            _time -= 0.05f;
            _reloadImage.fillAmount = _time / _timeReload;
        }
        _reloadImage.fillAmount = 1;
        _currentAmmoMagazine = _maxAmmoMagazine;
        _canFire = true;
        _textAmmo.text = $"{_currentAmmoMagazine} / {_maxAmmoMagazine}";

        while (_reloadImage.color.a > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            _reloadImage.color -= new Color(0, 0, 0, Time.deltaTime * 10);
        }
        _reloadImage.color = new Color(1, 1, 1, 0);
    }

    private IEnumerator DelayShoot()
    {
        _canFire = false;
        _time = _delayShoot;
        while (_time > 0)
        {
            _time -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        _canFire = true;
    }

    private IEnumerator Wait()
    {
        while (_time > 0)
        {
            _time -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        _canFire = true;
        if (_currentAmmoMagazine <= 0)
        {
            _currentAmmoMagazine = _maxAmmoMagazine;
        }
    }
}