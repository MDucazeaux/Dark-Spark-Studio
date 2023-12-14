using UnityEngine;

public class WitchActions : MonoBehaviour
{
    [SerializeField] private GameObject FireBall;

    public void ActionOne()
    {
        GameObject fireBall = Instantiate(FireBall);
        fireBall.GetComponent<FireBall>().SetValues();

    }
}
