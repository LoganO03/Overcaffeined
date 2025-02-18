using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


public enum InteractableType 
{
    ITEM,
    NPC,
}

public enum Item 
{
    BEAN,
    MUG,
    MILK,
}



public class Interactable : MonoBehaviour
{
    public InteractableType type;
    public Item item;

    [Header("NPC Settings")]

    [SerializeField] public Dialogue dialogue;
    [SerializeField] public string npcName;

    private bool firstInteraction = true;
    [SerializeField] private int repeatStartPosition;

    public int StartPosition
    {
        get
        {
            if (firstInteraction)
            {
                firstInteraction = false;
                return 0;
            }
            else
            {
                return repeatStartPosition;
            }
        }
    }

    //[Header("Item Settings")]



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
