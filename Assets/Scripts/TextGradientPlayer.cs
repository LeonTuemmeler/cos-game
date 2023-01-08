using TMPro;
using UnityEngine;

public enum LoopMethod
{
    Loop,
    PingPong,
    Once
}

public class TextGradientPlayer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Gradient gradient;
    [SerializeField] private LoopMethod loopMethod;
    [SerializeField] private float speed;
    
    private void Update()
    {
        float time = 0f;
        time += Time.time * speed;
        
        switch (loopMethod)
        {
            case LoopMethod.Loop:
                time %= 1f;
                break;
            
            case LoopMethod.PingPong:
                time %= 2f;
                if (time > 1f)
                {
                    time = 2f - time;
                }
                break;
            
            case LoopMethod.Once:
                time = Mathf.Clamp01(time);
                break;
        }
        
        text.color = gradient.Evaluate(time);
    }
}
