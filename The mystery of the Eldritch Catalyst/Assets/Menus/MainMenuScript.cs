using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public enum MENUSTATE
    {
        MAIN,
        CREDITS,
    }

    private MENUSTATE _state = MENUSTATE.MAIN;

    [SerializeField] private Transform _mainMenuPos;
    [SerializeField] private Transform _otherMenuPos;
    private Transform _cameraTransform;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        switch (_state)
        {
            case MENUSTATE.MAIN:
                _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _mainMenuPos.position, 4f * Time.deltaTime);
                break;
            case MENUSTATE.CREDITS:
                _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _otherMenuPos.position, 4f * Time.deltaTime);
                break;
        }
    }

    public void OnNewGame()
    {
        Debug.Log("new game");
    }

    public void OnSettings()
    {
        Debug.Log("Settings");
    }

    public void OnCredits()
    {
        _state = MENUSTATE.CREDITS;
    }

    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnGoToMain()
    {
        _state = MENUSTATE.MAIN;
    }

    public void SwitchState(string state)
    {
        switch (state)
        {
            case "Main":
                _state = MENUSTATE.MAIN;
                break;
            case "Credits":
                _state = MENUSTATE.CREDITS;
                break;
            default:
                Debug.Log("ERROR " + state + " state doesn't exist");
                break;
        }
    }
}
