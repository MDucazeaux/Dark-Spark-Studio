using System.Linq;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Transform _transform;
    const float c_tileSize = 10;

    private void Awake()
    {
        _transform = transform;
    }
    public void Interact()
    {
        GetInteractable();
    }

    private void GetInteractable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, c_tileSize, 1 << LayerMask.NameToLayer("Interactable"));
        if (colliders.Length > 0 )
        {
            colliders.OrderBy(x => Vector3.Distance(_transform.position, x.transform.position));
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].GetComponent<Interactable>().CanInteract())
                {
                    colliders[i].GetComponent<Interactable>().Interaction();
                    break;
                }
                
            }
            
        }
        
    }
}

