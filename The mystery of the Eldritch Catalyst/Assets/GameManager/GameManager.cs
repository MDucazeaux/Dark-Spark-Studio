using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerController playerController;

    public enum NaratifPhase
    {
        Intro, BeforeBossFight, GoodEnd, BadEnd, None
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        playerController.enabled = false;
    }

    public void LaunchGame()
    {
        playerController.enabled = true;
    }

    public void LaunchDialogueBeforeBossFight()
    {
        PlayerController.Instance.enabled = false;
        NarratifManager.Instance.ChangePhase(NaratifPhase.BeforeBossFight);
    }

    public void LaunchBossFight()
    {
        playerController.enabled = true;
    }
}
