using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableCamera : MonoBehaviour
{
    private void Start()
    {
        var position = transform.position;
        
        position = new Vector3(position.x, PlayerCamera.Y_OFFSET, position.z);
        transform.position = position;
    }
}
