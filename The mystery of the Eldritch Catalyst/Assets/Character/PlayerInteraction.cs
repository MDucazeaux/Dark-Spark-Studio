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

                if (colliders[i].TryGetComponent(out Button button))
               
                {
                    button.Interaction();
                    break;
                }
                else if (colliders[i].TryGetComponent(out Door door))
                {
                    if (door.CanInteract())
                    {
                        if (Inventory.Instance.IsInInventory("Key"))
                        {
                            door.Interaction();
                            Inventory.Instance.RemoveItemByName("Key");
                            break;
                        }
                        else
                        {
                            NarratifManager.Instance.FeedBackNoKey();
                            break;
                        }
                    }
                }
                else if (colliders[i].TryGetComponent(out Chest chest))
                {
                    if (chest.CanInteract())
                    {
                        if (Inventory.Instance.IsInInventory("Key"))
                        {
                            chest.Interaction();
                            Inventory.Instance.RemoveItemByName("Key");
                            break;
                        }
                        else
                        {
                            NarratifManager.Instance.FeedBackNoKey();
                            break;
                        }
                    }
                }
                
            }
            
        }
        
    }
}

