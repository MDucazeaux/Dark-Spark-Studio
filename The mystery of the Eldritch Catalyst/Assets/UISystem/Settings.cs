using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    [SerializeField] private GameObject _canvas;

    [SerializeField] private Image _backgroundPanel;

    [SerializeField] private Slider _mainVolSlider;
    [SerializeField] private Slider _sfxVolSlider;
    [SerializeField] private Slider _musicVolSlider;

    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private Toggle _fullscreenToggle;

    private float _mainVolume;
    private float _sfxVolume;
    private float _musicVolume;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(_canvas);
            return;
        }
        Instance = this;
        _mainVolSlider.onValueChanged.AddListener(delegate { OnMainVolumeChanged(); });
        _sfxVolSlider.onValueChanged.AddListener(delegate { OnSfxVolumeChanged(); });
        _musicVolSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChanged(); });
        _resolutionDropdown.value = 3;
        _fullscreenToggle.isOn = Screen.fullScreen;
        DontDestroyOnLoad(_canvas);
        gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        gameObject.SetActive(false);
    }

    public void OnFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void OnResolutionChange()
    {
        switch (_resolutionDropdown.value)
        {
            case 0:
                Screen.SetResolution(640, 360, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(2560, 1440, Screen.fullScreen);
                break;
        }
    }

    public void OnMainVolumeChanged()
    {
        _mainVolume = _mainVolSlider.value;
        SoundsManager.Instance.MusicsPlayerAudioSource.volume = _mainVolume * _musicVolume;
    } 

    public void OnSfxVolumeChanged()
    {
        _sfxVolume = _sfxVolSlider.value;
    }

    public void OnMusicVolumeChanged()
    {
        _musicVolume = _musicVolSlider.value;
        SoundsManager.Instance.MusicsPlayerAudioSource.volume = _mainVolume * _musicVolume;
    }

    public float MainVolume { get { return _mainVolume; } }
    public float SfxVolume { get { return _sfxVolume; } }
    public float MusicVolume {  get { return _musicVolume; } }
}
