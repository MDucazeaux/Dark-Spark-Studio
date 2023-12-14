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
                if (_aiDetection.CanSeePlayer())
                {
                    _state = STATES.MOVING;
                    break;
                }
                break;
            case STATES.MOVING:
                if (_aiDetection.CanSeePlayer())
                {
                    _aiMovement.SetTargetTo(_aiDetection.GetPlayerPos());
                    if (_aiDetection.IsNearPlayer())
                    {
                        _state = STATES.ATTACKING;
                        break;
                    }
                    _aiMovement.Move();
                }
                else
                {
                    _state = STATES.MOVELASTSIGHT;
                    break;
                }
                break;
            case STATES.ATTACKING:
                if (_aiDetection.IsNearPlayer())
                {
                    _aiAttack.AttackPlayer();
                }
                else
                {
                    _state = STATES.MOVING;
                }
                break;
            case STATES.MOVELASTSIGHT:
                _aiMovement.Move();
                if (_aiDetection.CanSeePlayer())
                {
                    _state = STATES.MOVING;
                    break;
                }
                if (_aiMovement.IsAtTarget())
                {
                    _state = STATES.IDLE;
                    break;
                }
                break;
            default:
                Debug.Log("AI STATES ERROR");
                break;
        }
    }
}
