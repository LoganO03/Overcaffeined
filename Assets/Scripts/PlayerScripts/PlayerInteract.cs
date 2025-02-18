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
            GameManager.Instance.SkipLine();
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
                        GameManager.Instance.AddItem(interactable.item);
                        GameManager.Instance.startConvo(interactable.dialogue.dialogue, interactable.StartPosition, interactable.npcName);
                    }
                    else if (interactable.type == InteractableType.NPC)
                    {
                        GameManager.Instance.startConvo(interactable.dialogue.dialogue, interactable.StartPosition, interactable.npcName);
                    }
                    if (interactable.searchingSound != null)
                    {
                        GameObject go = GameObject.Instantiate(interactable.searchingSound);
                        Destroy(go, 2);
                    }
                    
                }
            }
        }
    }

    void JoinConversation()
    {
        inConversation = true;
    }

    void LeaveConversation()
    {
        inConversation = false;
    }

    private void OnEnable()
    {
        GameManager.OnDialogueStarted += JoinConversation;
        GameManager.OnDialogueEnded += LeaveConversation;
    }

    private void OnDisable()
    {
        GameManager.OnDialogueStarted -= JoinConversation;
        GameManager.OnDialogueEnded -= LeaveConversation;
    }
}
