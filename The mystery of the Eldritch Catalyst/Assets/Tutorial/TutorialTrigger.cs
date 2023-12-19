using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    private enum MODE
    {
        NEXT_TUTORIAL,
        SHOW_TEXT,
        HIDE_TEXT,
        NEXT_AND_SHOW,
    }

    [SerializeField] private MODE _mode;

    [SerializeField] private TutorialScript _tutorialScript;

    [SerializeField] private int _checkId = -1;

    private bool _bisActivated = true;

    private void OnTriggerEnter(Collider other)
    {
        if (_checkId == -1 | _checkId == _tutorialScript.TutorialId)
        {
            if (other.name.Contains("Player") && _bisActivated)
            {
                switch (_mode)
                {
                    case MODE.NEXT_TUTORIAL:
                        _tutorialScript.NextTutorial();
                        break;
                    case MODE.NEXT_AND_SHOW:
                        _tutorialScript.NextTutorial();
                        _tutorialScript.IsVisible = true;
                        break;
                    case MODE.SHOW_TEXT:
                        _tutorialScript.IsVisible = true;
                        break;
                    case MODE.HIDE_TEXT:
                        _tutorialScript.IsVisible = false;
                        break;
                }
                _bisActivated = false;
            }
        }
    }
}
