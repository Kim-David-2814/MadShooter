using Scripts.Component;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Component
{
    public class KeyComponent : MonoBehaviour
    {
        [SerializeField] private GateComponent _gate;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("GG"))
            {
                _gate.OpenGate();
                Destroy(gameObject);
            }
        }
    }

}

