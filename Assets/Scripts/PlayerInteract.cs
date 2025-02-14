using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    float interactDistance = 2;
    bool inConversation = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("yum");
            Interact();
        }
    }

    void Interact()
    {
        if (inConversation)
        {
            Debug.Log("Skipping Line");
            //GameManager.Instance.SkipLine();
        }
        else
        {
            Debug.Log("Ray");
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, interactDistance, Vector2.up, 0, LayerMask.GetMask("Interactables"));
            if (hit)
            {
                Debug.Log("Hit Something!!" + hit.collider.gameObject.name);

                if (hit.collider.gameObject.TryGetComponent(out Interactable interactable))
                {
                    if (interactable.type == InteractableType.ITEM)
                    {
                        Debug.Log("you touched a coin");
                    }
                    else if (interactable.type == InteractableType.NPC)
                    {

                    }
                    
                    //GameManager.Instance.StartDialogue(npc.dialogueAsset.dialogue, npc.StartPosition, npc.npcName);
                }
            }
        }
    }
}
