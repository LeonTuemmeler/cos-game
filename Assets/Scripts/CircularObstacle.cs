using UnityEditor;
using UnityEngine;

public class CircularObstacle : MonoBehaviour
{
    [SerializeField] public float radius = 1f;
    [SerializeField] private float speed = 2f;
    [SerializeField] public Vector3 obstacleSize;

    [SerializeField] private GameObject obstacle;
    private Transform _obstacleInstance;
    private float time = 0f;
    
    [Header("Gizmos")]
    [SerializeField] public float gizmoObstacleValue = 0f;
    [SerializeField] public Color circleColor = Color.blue;
    [SerializeField] public Color obstacleColor = Color.red;

    private void Start()
    {
        _obstacleInstance = Instantiate(obstacle).transform;
        _obstacleInstance.parent = transform;
        _obstacleInstance.localPosition = GetPointLocal(0);
        _obstacleInstance.localScale = obstacleSize;

        var renderer = _obstacleInstance.GetComponentInChildren<Renderer>();
        renderer.material.color = obstacleColor;
    }
    
    private void Update()
    {
        var pos = GetPoint(time);
        _obstacleInstance.position = pos;

        time += Time.deltaTime * speed;
    }

    public Vector3 GetPoint(float x)
    {
        return GetPointLocal(x) + transform.position;
    }

    private Vector3 GetPointLocal(float x)
    {
        var xPos = Mathf.Sin(x) * radius;
        var yPos = Mathf.Cos(x) * radius;

        return new Vector3(xPos, 0, yPos);
    }
}

[CustomEditor(typeof(CircularObstacle))]
[CanEditMultipleObjects]
public class CircularObstacleEditor : Editor
{
    private void OnSceneGUI()
    {
        var t = target as CircularObstacle;
        var tr = t.transform;
        
        Handles.color = t.circleColor;
        Handles.DrawWireDisc(tr.position, tr.up, t.radius);

        Handles.color = t.obstacleColor;
        Handles.DrawWireCube(t.GetPoint(t.gizmoObstacleValue), t.obstacleSize);
        
        // Draw text with an outline
        Handles.Label(t.GetPoint(t.gizmoObstacleValue), t.name, new GUIStyle
        {
            normal = new GUIStyleState
            {
                textColor = Color.black,
                background = Texture2D.whiteTexture
            }
        });
    }
}