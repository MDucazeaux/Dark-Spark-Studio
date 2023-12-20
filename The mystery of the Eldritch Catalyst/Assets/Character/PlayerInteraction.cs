using System.Linq;
using Unity.VisualScripting;
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

        Collider[] colliders = Physics.OverlapSphere(transform.position, c_tileSize);

        if (colliders.Length > 0 )
        {
            colliders.OrderBy(x => Vector3.Distance(_transform.position, x.transform.position));

            for (int i = 0; i < colliders.Length; i++)
            {
                if (!colliders[i].CompareTag("Interactable"))
                {
                    continue;
                }
                if (colliders[i].TryGetComponent(out Button button))
                {
                    if (button.CanInteract())
                    {
                        button.Interaction();
                        break;
                    }
                }
                else if (colliders[i].TryGetComponent(out Door door))
                {
                    print("\n");
                    print(Inventory.Instance.IsInInventory("Key"));
                    print(door.IsLocked);
                    print(door.IsOpened);

                    if (door.CanInteract() && !door.IsLocked)
                    {
                        door.Interaction();
                        break;
                    }
                    
                    if (Inventory.Instance.IsInInventory("Key") && door.IsLocked && !door.IsOpened)
                    {
                        Inventory.Instance.RemoveItemByName("Key");
                        StartCoroutine(door.Open());
                        break;
                    }
                    else if (door.IsLocked && !door.IsOpened)
                    {
                        NarratifManager.Instance.FeedBackNoKey();
                        break;
                    }
                }
                else if (colliders[i].TryGetComponent(out Chest chest))
                {
                    if (chest.CanInteract())
                    {
                        chest.Interaction();
                    }
                    else
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

