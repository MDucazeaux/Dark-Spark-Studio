using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
        PlayerController.Instance.enabled = false;
        ContinualLossOfEnergy.Instance.enabled = false;
        Boss.SetActive(false);
        Boss.GetComponent<AIController>().enabled = false;
    }

    public void LaunchGame()
    {
        PlayerController.Instance.enabled = true;
        ContinualLossOfEnergy.Instance.enabled = true;
    }

    public void LaunchDialogueBeforeBossFight()
    {
        Boss.SetActive(true);
        PlayerController.Instance.enabled = false;
        ContinualLossOfEnergy.Instance.enabled = false;
        PlayerRotation.Instance.SetDirection(2);
        NarratifManager.Instance.ChangePhase(NaratifPhase.BeforeBossFight);

    }

    public void LaunchBossFight()
    {
        PlayerController.Instance.enabled = true;
        ContinualLossOfEnergy.Instance.enabled = true;
        Boss.GetComponent<AIController>().enabled = true;
    }
}