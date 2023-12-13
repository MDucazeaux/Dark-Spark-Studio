using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] AIMovement _aiMovement;
    [SerializeField] AIDetection _aiDetection;
    [SerializeField] AIAttack _aiAttack;

    private enum STATES
    {
        IDLE,
        MOVING,
        ATTACKING,
        MOVELASTSIGHT,
    }

    private STATES _state = STATES.IDLE;

    private void Update()
    {
        switch (_state)
        {
            case STATES.IDLE:
                _aiMovement.SetTargetTo(_aiDetection.GetPlayerPos());
                _aiMovement.Move();
                break;
            case STATES.MOVING:
                break;
            case STATES.ATTACKING:
                break;
            case STATES.MOVELASTSIGHT: 
                break;
            default:
                Debug.Log("AI STATES ERROR");
                break;
        }
    }
}
