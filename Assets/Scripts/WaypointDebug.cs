using UnityEngine;

public class WaypointDebug : MonoBehaviour
{
    [SerializeField] private Transform platform;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        
        var platformRotation = platform.rotation;
        var platformScale = platform.lossyScale;

        Gizmos.matrix = Matrix4x4.TRS(transform.position, platformRotation, platformScale);
        
        // draw a cube with the position, rotation and scale
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}
