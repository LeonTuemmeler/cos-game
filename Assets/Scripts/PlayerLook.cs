using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSpeed = 500f;

    private void Start()
    {
        // Lock Mouse
        Cursor.lockState = CursorLockMode.Locked;
        
        #if UNITY_EDITOR
        mouseSpeed *= 2;
        #endif
    }

    void Update()
    {
        var xInput = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        transform.Rotate(transform.up, xInput);
    }
}
