using UnityEngine;

public class DialogueBossTrigger : MonoBehaviour
{
    private bool _balreadyActivated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_balreadyActivated)
        {
            GameManager.Instance.LaunchDialogueBeforeBossFight();
            _balreadyActivated = true;
        }
    }
}
