using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject Boss;

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
        Boss.SetActive(false);
        Boss.GetComponent<AIController>().enabled = false;
    }

    public void LaunchGame()
    {
        playerController.enabled = true;
    }

    public void LaunchDialogueBeforeBossFight()
    {
        Boss.SetActive(true);
        PlayerController.Instance.enabled = false;
        PlayerRotation.Instance.SetDirection(2);
        NarratifManager.Instance.ChangePhase(NaratifPhase.BeforeBossFight);

    }

    public void LaunchBossFight()
    {
        playerController.enabled = true;
        Boss.GetComponent<AIController>().enabled = true;
    }
}