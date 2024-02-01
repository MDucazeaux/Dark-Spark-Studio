using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GamepadManager : StandaloneInputModule
{
    public static GamepadManager Instance;
    public bool GamepadDetected = false;

    Vector2 rightStickValue = Vector2.zero;

    protected override void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (rightStickValue != Vector2.zero)
        {
            Mouse.current.WarpCursorPosition(new Vector2(Input.mousePosition.x + rightStickValue.x * 1200 * Time.deltaTime, Input.mousePosition.y + rightStickValue.y * 1200 * Time.deltaTime));
        }
    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        rightStickValue = context.ReadValue<Vector2>();
        GamepadDetected = true;
    }
    
    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ClickAt(Input.mousePosition.x, Input.mousePosition.y);
            GamepadDetected = true;
        }
    }

    public void ClickAt(float x, float y)
    {
        Input.simulateMouseWithTouches = true;
        var pointerData = GetTouchPointerEventData(new Touch()
        {
            position = new Vector2(x, y),
        }, out bool b, out bool bb);

        ProcessTouchPress(pointerData, true, true);
    }
}
