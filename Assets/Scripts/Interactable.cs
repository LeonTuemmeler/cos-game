using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected UnityEvent<float> onInteract;
    [SerializeField] protected UnityEvent<float> onHover;
    [SerializeField] protected float distance = 3f;
    
    [HideInInspector] public bool isInteractionInReach;

    public void Debug(string msg)
    {
        print(msg);
    }

    private float GetDistance(Vector3 camPos)
    => Vector3.Distance(transform.position, camPos);

    public virtual void Interact(Vector3 camPos)
    {
        var interactorDistance = GetDistance(camPos);
        
        if (!IsInRange(camPos))
            return;
        
        onInteract.Invoke(interactorDistance);
    }
    
    public virtual void Hover(Vector3 camPos)
    {
        var interactorDistance = GetDistance(camPos);
        
        if (!IsInRange(camPos))
            return;
        
        onHover.Invoke(interactorDistance);
    }
    
    public bool IsInRange(Vector3 camPos)
    {
        var interactableDistance = GetDistance(camPos);
        
        return interactableDistance <= distance;
    }
}
