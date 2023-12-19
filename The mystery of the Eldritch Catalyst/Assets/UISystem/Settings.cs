using System;
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

    [SerializeField] private Image _blackFilter;

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
