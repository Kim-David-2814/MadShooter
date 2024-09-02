using Scripts.Component;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoss : MonoBehaviour
{

    [SerializeField] private GameObject _objectToWatch;
    [SerializeField] private GateComponent _gate;

    private void Update()
    {
        if (_objectToWatch == null)
        {
            _gate.OpenGate();
        }
    }
}
