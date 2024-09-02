using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Component
{
    public class GateComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Collider2D _collider;
        private bool _isOpen = false;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void OpenGate()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                _animator.SetTrigger("Gate");
                _collider.enabled = false;
            }
        }
    }
}
