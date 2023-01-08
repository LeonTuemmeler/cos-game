using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteractable : Interactable
{
    [SerializeField] private int sceneIndex;
    
    private void Start()
    {
        onInteract.AddListener(call =>
        {
            SceneManager.LoadScene(sceneIndex);
        });
    }
}
