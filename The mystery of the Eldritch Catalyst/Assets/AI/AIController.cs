using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] AIMovement _aiMovement;
    [SerializeField] AIDetection _aiDetection;
    [SerializeField] AIAttack _aiAttack;
    [SerializeField] AIAnimation _aiAnimation;

    private enum STATES
    {
        IDLE,
        MOVING,
        ATTACKING,
        MOVELASTSIGHT,
        DEAD,
    }

    private STATES _state = STATES.IDLE;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _state = STATES.DEAD;
        }

        switch (_state)
        {
            case STATES.IDLE:
                if (_aiDetection.CanSeePlayer())
                {
                    _state = STATES.MOVING;
                    _aiAnimation.AnimatorSetBool("Walking", true);
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
                        _aiAnimation.AnimatorSetBool("Walking", false);
                        _aiAnimation.AnimatorSetBool("Attacking", true);
                        break;
                    }
                    _aiMovement.Move();
                }
                else
                {
                    _state = STATES.MOVELASTSIGHT;
                    _aiAnimation.AnimatorSetBool("Walking", true);
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
                    _aiAnimation.AnimatorSetBool("Walking", true);
                    _aiAnimation.AnimatorSetBool("Attacking", false);
                }
                break;
            case STATES.MOVELASTSIGHT:
                _aiMovement.Move();
                if (_aiDetection.CanSeePlayer())
                {
                    _state = STATES.MOVING;
                    _aiAnimation.AnimatorSetBool("Walking", true);
                    break;
                }
                if (_aiMovement.IsAtTarget())
                {
                    _state = STATES.IDLE;
                    _aiAnimation.AnimatorSetBool("Walking", false);
                    break;
                }
                break;
            case STATES.DEAD:
                _aiAnimation.AnimatorSetBool("Dead", true);
                break;
            default:
                Debug.Log("AI STATES ERROR");
                break;
        }
    }
}
