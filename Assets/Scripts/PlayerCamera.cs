using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private float magnitudeThreshold;
    
    [Header("Cosine Settings")]
    [SerializeField] private float amplify = 1f;
    [SerializeField] private float duration = 1f;
    
    public static float Y_OFFSET = 0f;
    private float _moveTime = 0f;

    private Vector3 _offsetVector;

    private void Awake()
    {
        Y_OFFSET = camera.localPosition.y;
        _offsetVector = new Vector3(0, Y_OFFSET, 0);
    }

    public static float GetCosine(float time, float amplification, float length)
    {
        return Mathf.Cos(time * length) * amplification;
    }
    
    public void MoveCamera(float magnitude)
    {
        if (magnitude < magnitudeThreshold)
        {
            _moveTime = 0f;
            camera.localPosition = _offsetVector;
            return;
        }

        // Get Cosine Value
        var cosine = GetCosine(_moveTime, amplify, duration) + Y_OFFSET;
        _moveTime += Time.deltaTime;
        
        // Create Camera Position
        var camPos = new Vector3(0, cosine, 0);
        
        // Set Camera Position
        camera.localPosition = camPos;
    }
}
