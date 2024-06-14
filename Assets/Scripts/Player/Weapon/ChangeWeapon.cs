using UnityEngine;
using System.Collections;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons;
    private int _weaponIndex = 0;

    private void Awake()
    {
        _weapons[_weaponIndex].gameObject.SetActive(true);
        for (int i = 1; i < _weapons.Length; i++)
        {
            _weapons[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(UpScroll());
        StartCoroutine(DownScroll());
    }

    private IEnumerator UpScroll()
    {
        yield return new WaitUntil(() => Input.GetAxis("Mouse ScrollWheel") > 0);
        _weapons[_weaponIndex].gameObject.SetActive(false);
        _weaponIndex++;
        if (_weaponIndex >= _weapons.Length)
        {
            _weaponIndex = 0;
        }
        _weapons[_weaponIndex].gameObject.SetActive(true);
        StartCoroutine(UpScroll());
    }

    private IEnumerator DownScroll()
    {
        yield return new WaitUntil(() => Input.GetAxis("Mouse ScrollWheel") < 0);
        _weapons[_weaponIndex].gameObject.SetActive(false);
        _weaponIndex--;
        if (_weaponIndex < 0)
        {
            _weaponIndex = _weapons.Length - 1;
        }
        _weapons[_weaponIndex].gameObject.SetActive(true);
        StartCoroutine(DownScroll());
    }
}