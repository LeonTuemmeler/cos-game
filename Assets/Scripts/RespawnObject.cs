using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class RespawnObject : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Transform respawnPoint;

    private void Start()
    {
        if (respawnPoint == null)
        {
            respawnPoint = transform;
        }
        
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            var player = other.GetComponent<PlayerMovement>();
            player.SetPosition(respawnPoint.position);
        }
    }
}
