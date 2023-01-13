using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject exitBlock;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    private int _currentWaypointIndex = 0;
    private bool _isMoving = false;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        MoveToFirstWaypoint();
    }

    public void Move()
    {
        _isMoving = true;
    }
    
    public void MoveToFirstWaypoint()
    {
        _currentWaypointIndex = 0;
        Move();
    }

    private void Update()
    {
        exitBlock.SetActive(_isMoving);
        _playerMovement.ToggleJump(!_isMoving);

        if (!_isMoving)
            return;
        
        var waypointDistance = Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].position);
        if (waypointDistance < 0.1f)
        {
            _isMoving = false;
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }

        if (_currentWaypointIndex < waypoints.Length)
            transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypointIndex].position,
                speed * Time.deltaTime);
    }
}
