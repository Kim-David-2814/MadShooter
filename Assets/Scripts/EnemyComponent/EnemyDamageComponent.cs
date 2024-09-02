using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageComponent : MonoBehaviour
{
    [SerializeField] private float _damage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GG"))
        {
            collision.GetComponent<HealthComponent>().TakeDamage(_damage);
        }

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<HealthComponent>().TakeDamage(_damage);
        }
    }
}
