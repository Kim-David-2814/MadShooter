using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollected : MonoBehaviour
{
    [SerializeField] private float _healing;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GG"))
        {
            collision.GetComponent<HealthComponent>().TakeHealth(_healing);
            gameObject.SetActive(false);
        }
    }
}
