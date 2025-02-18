using UnityEngine;

public class ManagerController : MonoBehaviour
{
    [SerializeField] Dialogue endingDialogue;
    [SerializeField] Dialogue gotMilkDialogue;
    [SerializeField] Dialogue gotMugDialogue;

    [SerializeField] private int gotMilkDialogueRepeatLocation;
    [SerializeField] private int gotMugDialogueRepeatLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (GameManager.Instance.hasAllItems())
        {
            gameObject.GetComponent<Interactable>().dialogue = endingDialogue;
            gameObject.GetComponent<Interactable>().makeEndGame();
            gameObject.GetComponent<Interactable>().firstInteraction = true;
        }
        else if (GameManager.Instance.getHasMugandMilk())
        {
            gameObject.GetComponent<Interactable>().dialogue = gotMugDialogue;
            gameObject.GetComponent<Interactable>().repeatStartPosition = gotMugDialogueRepeatLocation;
            gameObject.GetComponent<Interactable>().firstInteraction = true;
        }
        else if (GameManager.Instance.getHasMilk())
        {
            gameObject.GetComponent<Interactable>().dialogue = gotMilkDialogue;
            gameObject.GetComponent<Interactable>().repeatStartPosition = gotMilkDialogueRepeatLocation;
            gameObject.GetComponent<Interactable>().firstInteraction = true;
        }
       
    }
}
