using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Component
{
    public class FrameSwitchComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _activFrame;
        [SerializeField] private Collider2D _collider;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("GG"))
            {
                Destroy(_activFrame);
                _collider.enabled = true;
            }
        }
    }

}