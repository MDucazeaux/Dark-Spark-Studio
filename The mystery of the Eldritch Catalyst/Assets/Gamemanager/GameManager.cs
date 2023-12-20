using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject Boss;
    [SerializeField] private Transform _rotationToDoor;

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

        PlayerMovement.Instance.SetDirection(Vector2.zero);
        PlayerMovement.Instance.transform.position -= new Vector3(PlayerMovement.Instance.transform.position.x % 10, 0, PlayerMovement.Instance.transform.position.z % 10);

        ContinualLossOfEnergy.Instance.enabled = false;

        Vector3 pPosition = PlayerMovement.Instance.transform.position;
        Vector3 deltaPosition = _rotationToDoor.transform.position - pPosition;
        float dir = Vector3.Dot(PlayerMovement.Instance.transform.forward.normalized, deltaPosition.normalized);
        float dir2 = Vector3.Dot(PlayerMovement.Instance.transform.right.normalized, deltaPosition.normalized);
        Debug.Log(dir);
        if (dir > 0.5f) 
        {
            PlayerRotation.Instance.SetDirection(0);
        }
        else if (dir < -0.5f)
        {
            PlayerRotation.Instance.SetDirection(2);
        }
        else if (dir2 > 0.5f)
        {
            PlayerRotation.Instance.SetDirection(1);
        }
        else
        {
            PlayerRotation.Instance.SetDirection(-1);
        }
        
        NarratifManager.Instance.ChangePhase(NaratifPhase.BeforeBossFight);
    }

    public void LaunchBossFight()
    {
        PlayerController.Instance.enabled = true;
        ContinualLossOfEnergy.Instance.enabled = true;
        Boss.GetComponent<AIController>().enabled = true;
    }
}