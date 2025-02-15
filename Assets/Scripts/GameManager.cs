using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using System.Collections;
using System;

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

    [SerializeField] private GameObject convoCanvas;

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI convoText;

    public static event Action OnDialogueStarted;
    public static event Action OnDialogueEnded;
    bool skipLineTriggered;

    public void startConvo(string[] dialogue, int startPosition, string name) 
    {
        nameText = convoCanvas.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        convoText = convoCanvas.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();

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
