using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] private int health;

    [SerializeField] private GameObject convoCanvas;

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI convoText;

    [SerializeField] private GameObject inGameUICanvas;
    [SerializeField] private GameObject HeartPanel;
    [SerializeField] private GameObject BeanImage;
    [SerializeField] private GameObject MugImage;
    [SerializeField] private GameObject MilkImage;

    public static event Action OnDialogueStarted;
    public static event Action OnDialogueEnded;
    bool skipLineTriggered;

    [SerializeField] private bool hasBean = false;
    [SerializeField] private bool hasMug = false;
    [SerializeField] private bool hasMilk = false;

    private bool gameHasEnded = false;


    public void startConvo(string[] dialogue, int startPosition, string name) 
    {
        nameText = convoCanvas.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        convoText = convoCanvas.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        nameText.text = name;
        convoCanvas.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(RunDialogue(dialogue, startPosition));
    }

    public void startConvo(string[] dialogue, int startPosition, string name, bool endsGame)
    {
        nameText = convoCanvas.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        convoText = convoCanvas.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        gameHasEnded = endsGame;

        nameText.text = name;
        convoCanvas.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(RunDialogue(dialogue, startPosition));
    }

    IEnumerator RunDialogue(string[] dialogue, int startPosition)
    {
        skipLineTriggered = false;
        OnDialogueStarted?.Invoke();

        for (int i = startPosition; i < dialogue.Length; i++)
        {
            Debug.Log(dialogue[i]);
            convoText.text = dialogue[i];

            while (skipLineTriggered == false)
            {
                // Wait for the current line to be skipped
                yield return null;
            }
            skipLineTriggered = false;
        }

        OnDialogueEnded?.Invoke();
        convoCanvas.SetActive(false);
    }

    public void SkipLine()
    {
        skipLineTriggered = true;
    }

    public void EndDialogue()
    {
        nameText.text = null;
        convoText.text = null;
        convoCanvas.SetActive(false);
        if (gameHasEnded) 
        {
            //put end game code
        }
    }

    public void AddItem(Item item) 
    {
        //add logic to make game know you have the items and add them to the UI
        switch (item) 
        {
            case Item.BEAN:
                BeanImage.SetActive(true);
                hasBean = true;
                break;
            case Item.MUG:
                MugImage.SetActive(true);
                hasMug = true;
                break;
            case Item.MILK:
                MilkImage.SetActive(true);
                hasMilk = true;
                break;
        }
    }

    public void ShowHearts() 
    {
        for (int i = 0; i < health; i++) 
        {
            HeartPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = health; i < 5; i++)
        {
            HeartPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public bool hasAllItems() 
    {
        return (hasMilk && hasBean && hasMug);
    }

    public bool getHasMilk() 
    {
        return hasMilk;
    }

    public bool getHasMugandMilk() 
    {
        Debug.Log("mug and milk");
        return (hasMug && hasMilk);
    }

    public void ChangeHealth(int newHealth) 
    {
        health = newHealth;
        ShowHearts();
    }

    public void EnableUI(bool enable) 
    {
        inGameUICanvas.gameObject.SetActive(enable);
    }

    public void StartGame() 
    {
        hasBean = false;
        hasMug = false;
        hasMilk = false;

        Initiate.Fade("PlayArea", Color.black, 1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
