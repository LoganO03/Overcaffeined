using NUnit.Framework.Constraints;
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
    [SerializeField] public GameObject searchingSound;

    private bool firstInteraction = true;
    public int repeatStartPosition;

    private bool interactingEndsGame = false;

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

    public void makeEndGame() 
    {
        interactingEndsGame = true;
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
