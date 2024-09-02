using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] private HeroMove _shooterComponent;
    [SerializeField] private Image _totalAmmoBar;
    [SerializeField] private Image _currentAmmoBar;

    private void Start()
    {
        _totalAmmoBar.fillAmount = _shooterComponent._currentAmmo / 4;
    }

    private void Update()
    {
        UpdateAmmoBar();
    }

    private void UpdateAmmoBar()
    {
        _currentAmmoBar.fillAmount = _shooterComponent._currentAmmo / 4;
    }
}