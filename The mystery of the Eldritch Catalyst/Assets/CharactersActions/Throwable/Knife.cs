using UnityEngine;

public class Knife : Throwable
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

        }
    }
}
