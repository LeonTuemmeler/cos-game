using System;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class RandomRotate : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minX = -359f;
    [SerializeField] private float maxX = 359f;
    [SerializeField] private float minY = -359f;
    [SerializeField] private float maxY = 359f;
    [SerializeField] private float minZ = -359f;
    [SerializeField] private float maxZ = 359f;

    private void Start()
    {
        // Zufällige Rotation zuweisen
        transform.rotation = GenerateRotation();
    }

    private Quaternion GenerateRotation()
    {
        var x = Random.Range(minX, maxX);
        var y = Random.Range(minY, maxY);
        var z = Random.Range(minZ, maxZ);
        
        return new Quaternion(x, y, z, transform.rotation.w);
    }
    
    private void Update()
    {
        // Rotation um die eigene Achse
        transform.Rotate(Vector3.right * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
