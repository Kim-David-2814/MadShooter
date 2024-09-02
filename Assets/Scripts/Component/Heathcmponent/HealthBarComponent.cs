using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent _playerHealth;
    [SerializeField] private Image _totalHealtBar;
    [SerializeField] private Image _currentHealthBar;

    private void Start()
    {
        _totalHealtBar.fillAmount = _playerHealth._currentHealth / 10;
    }

    private void Update()
    {
        Hp();
    }

    private void Hp()
    {
        _currentHealthBar.fillAmount = _playerHealth._currentHealth / 10;
    }
}
