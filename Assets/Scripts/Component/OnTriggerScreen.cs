using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Component
{
    public class OnTriggerScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToActivate;
        [SerializeField] private string _playerTag;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(_playerTag))
            {
                _objectToActivate.SetActive(true);
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {

            if (other.CompareTag(_playerTag))
            {
                _objectToActivate.SetActive(false);
            }
        }
    }
}