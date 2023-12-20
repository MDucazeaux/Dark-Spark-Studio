using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] private List<Gate> _gates = new List<Gate>();
    [SerializeField] private bool _CloseMode = true;

    private bool _bisActive = true;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !_bisActive)
        {
            for (int i =0; i < _gates.Count; i++)
            {
                if (_CloseMode && _gates[i].IsOpened)
                {
                    StartCoroutine(_gates[i].Close());
                    _bisActive = false;
                }
                else if (!_CloseMode && !_gates[i].IsOpened)
                {
                    StartCoroutine(_gates[i].Open());
                    _bisActive = false;
                }
            }
        }
    }
}
