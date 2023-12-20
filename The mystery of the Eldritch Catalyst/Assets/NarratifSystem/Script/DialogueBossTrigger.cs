using UnityEngine;

public class DialogueBossTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LaunchDialogueBeforeBossFight();
        }
    }
}
