using UnityEngine;

public class AreaDialogueTrigger : MonoBehaviour
{

    private bool firstInteraction = true;

    [SerializeField] Dialogue dialogue;

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
        if (firstInteraction)
        {
            if (collision != null && collision.TryGetComponent(out PlayerMovement pm))
            {
                firstInteraction = false;
                GameManager.Instance.startConvo(dialogue.dialogue, 0, "[Redacted]");
            }
        }
    }
}
