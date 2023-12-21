using System.Collections.Generic;
using UnityEngine;

public class ActionOnDeath : MonoBehaviour
{
    private enum ACTIONS
    {
        OPEN_GATE,
        END_CINEMATIC,
    }

    [SerializeField] private ACTIONS _doWhat = ACTIONS.OPEN_GATE;

    [SerializeField] private List<Gate> _gates = new List<Gate>();

    private void OnDestroy()
    {
        switch (_doWhat)
        {
            case ACTIONS.OPEN_GATE:
                for (int i = 0; i < _gates.Count; i++)
                {
                    if (!_gates[i].IsOpened)
                    {
                        _gates[i].OpenWithTrigger();
                    }
                }
                break;
            case ACTIONS.END_CINEMATIC:
                MenuManager.Instance.OpenWinAfterTimer(2);
                break;
        }
    }
}
