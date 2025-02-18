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
        }
        else if (GameManager.Instance.getHasMilk())
        {
            gameObject.GetComponent<Interactable>().dialogue = gotMilkDialogue;
            gameObject.GetComponent<Interactable>().repeatStartPosition = gotMilkDialogueRepeatLocation;
        }
        else if (GameManager.Instance.getHasMugandMilk()) 
        {
            gameObject.GetComponent<Interactable>().dialogue = gotMugDialogue;
            gameObject.GetComponent<Interactable>().repeatStartPosition = gotMugDialogueRepeatLocation;
        }
    }
}
