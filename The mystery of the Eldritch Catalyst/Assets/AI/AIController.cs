using Unity.VisualScripting;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] AIMovement _aiMovement;
    [SerializeField] AIDetection _aiDetection;
    [SerializeField] AIAttack _aiAttack;
    [SerializeField] AIAnimation _aiAnimation;

    GameObject _spriteObject;

    private enum STATES
    {
        IDLE,
        MOVING,
        ATTACKING,
        MOVELASTSIGHT,
        DEAD,
    }

    private STATES _state = STATES.IDLE;

    private void Start()
    {
        _spriteObject = transform.Find("Sprite").gameObject;
    }

    private void Update()
    {
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
                _aiAnimation.SetAnimatorSpeed(1 / GetComponent<Enemy>().GetCoolDownAttack());
                if (_aiDetection.IsNearPlayer())
                {
                    _aiAttack.AttackPlayer();
                }
                else
                {
                    _aiAnimation.SetAnimatorSpeed(1);
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
                if (_aiAnimation.AnimatorGetBool("Dead"))
                {
                    Destroy(gameObject, 0.31f);
                }
                _aiAnimation.AnimatorSetBool("Dead", true);
                break;
            default:
                Debug.Log("AI STATES ERROR");
                break;
        }
    }

    public void Death()
    {
        _state = STATES.DEAD;
        _aiAnimation.AnimatorSetBool("Dead", true);
    }
}
