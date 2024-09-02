using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] public float _maxHealth;
    [SerializeField] private Animator _anim;
    [SerializeField] private HeroMove _gg;

    public float _currentHealth { get; private set; }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _gg = GetComponent<HeroMove>();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        CheckAlive();
    }

    public void TakeHealth(float HP)
    {
        _currentHealth += HP;
    }

    private void CheckAlive()
    {
        if (_currentHealth < 0)
        {
            Destroy(gameObject);
            _gg.GetComponent<HeroMove>().Dead(2);
        }
        else
        {
            _anim.SetTrigger("Hit");
        }
    }
}
