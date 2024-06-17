using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private int _helth;

    private void Awake() => _slider.value = _slider.maxValue = _helth;

    public void TakeDamage(int damage)
    {
        _helth -= damage;
        _slider.value = _helth;
        if (_helth <= 0)
        {
            EndGame.Instance.End();
        }
    }
}