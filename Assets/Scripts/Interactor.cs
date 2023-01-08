using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    private Camera _camera;
    
    [Header("UI")]
    [SerializeField] private Image crosshair;

    [SerializeField] private Sprite defaultCrosshair;
    [SerializeField] private Sprite interactCrosshair;

    [Header("Layer")]
    [SerializeField] private LayerMask interactableLayer;

    private Interactable _previousFrameInteractable;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, interactableLayer);

        if (hit.collider == null)
        {
            crosshair.sprite = defaultCrosshair;
            return;
        }

        // Try to get Interactable Component
        var tryGet = hit.collider.TryGetComponent<Interactable>(out var interactable);

        if (!tryGet)
        {
            crosshair.sprite = defaultCrosshair;
            _previousFrameInteractable.isInteractionInReach = false;
            _previousFrameInteractable = null;
            return;
        }

        // Change crosshair
        crosshair.sprite = interactable.IsInRange(transform.position) ? interactCrosshair : defaultCrosshair;
        
        // Interact
        if (Input.GetButtonDown("Interact"))
        {
            interactable.Interact(transform.position);
            return;
        }
        
        interactable.Hover(transform.position);
        _previousFrameInteractable = interactable;
    }
}
