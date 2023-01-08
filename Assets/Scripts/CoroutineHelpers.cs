using System.Collections.Generic;
using UnityEngine;

public class CoroutineHelpers : MonoBehaviour
{
    private static Dictionary<float, WaitForSeconds> _waitTimes = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWait(float time)
    {
        if (!_waitTimes.ContainsKey(time))
        {
            _waitTimes.Add(time, new WaitForSeconds(time));
        }
        
        return _waitTimes[time];
    }
}
