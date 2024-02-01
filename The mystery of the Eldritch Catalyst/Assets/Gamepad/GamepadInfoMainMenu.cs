using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamepadInfo : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = "";
    }

    private void Update()
    {
        if (GamepadManager.Instance.GamepadDetected)
        {
            GetComponent<TextMeshProUGUI>().text = "Gamepad detected, move the cursor with the right joystick and click with <color=\"blue\">X</color>";
        }
    }
}
