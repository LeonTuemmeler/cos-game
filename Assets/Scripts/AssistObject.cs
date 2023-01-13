using UnityEngine;
using UnityEngine.Events;

public class AssistObject : MonoBehaviour
{
    private bool _assistOn = false;
    
    [Tooltip("Boolean determining if the assist object is on or off")]
    [SerializeField] private bool _assistState = true;
    [SerializeField] private UnityEvent<bool> _assistEvent;

    private void Start()
    {
        _assistOn = AssistMode.GetAssistMode();

        if (!_assistOn)
        {
            _assistEvent.Invoke(!_assistState);
            return;
        }

        _assistEvent.Invoke(_assistState);
    }
}
