using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private void Update()
    {
        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
        
        
    }
}
