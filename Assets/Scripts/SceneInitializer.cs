using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] private bool inGameUINeeded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.EnableUI(inGameUINeeded);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
}
