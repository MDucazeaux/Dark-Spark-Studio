using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public enum MENUSTATE
    {
        MAIN,
        CREDITS,
        LAUNCHING,
    }

    private MENUSTATE _state = MENUSTATE.MAIN;

    [SerializeField] private Transform _mainMenuPos;
    [SerializeField] private Transform _creditMenuPos;
    [SerializeField] private Transform _launchingMenuPos;
    private Transform _cameraTransform;
    private Transform _transform;

    [SerializeField] private Image _blackFilter;

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
                _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _creditMenuPos.position, 4f * Time.deltaTime);
                break;
            case MENUSTATE.LAUNCHING:
                //_cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _launchingMenuPos.position, 0.1f * Time.deltaTime);
                break;
        }
    }

    public void OnNewGame()
    {
        _state = MENUSTATE.LAUNCHING;
        StartCoroutine(StartingGame());
    }

    private IEnumerator StartingGame()
    {
        float _elapsedTime = 0f; 
        while (_elapsedTime < 4) 
        {
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _launchingMenuPos.position, (_elapsedTime/7) * Time.deltaTime);
            _blackFilter.color = Color.Lerp(_blackFilter.color, new Color(0, 0, 0, 1), (_elapsedTime / 3) * Time.deltaTime);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadSceneAsync("GameScene");
        yield return null;
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
