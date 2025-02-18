using UnityEngine;

public class InteractableNoticeTrigger : MonoBehaviour
{
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
        if (collision != null && collision.TryGetComponent(out PlayerMovement pm))
        { 
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.TryGetComponent(out PlayerMovement pm))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
