using System.Collections;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed = 1f;
    [SerializeField] private Vector3 _scaleStart = Vector3.zero;
    [SerializeField] private Vector3 _scaleEnd = Vector3.one;
    [SerializeField] private bool _isLoop = false;
    [SerializeField] private AnimationCurve _curve = AnimationCurve.Linear(0, 0, 1, 1);

    IEnumerator IPlayAnimation()
    {
        transform.localScale = _scaleStart;
        float time = 0;

        while (time < 1)
        {
            var scale = Vector3.Lerp(_scaleStart, _scaleEnd, _curve.Evaluate(time));
            transform.localScale = scale;
            
            time += Time.deltaTime * _scaleSpeed;
            yield return null;
        }
        
        transform.localScale = _scaleEnd;
        
        if (_isLoop)
        {
            StartCoroutine(IPlayAnimation());
        }
    }

    public void Play()
    {
        StartCoroutine(IPlayAnimation());
    }

    public void End()
    {
        StopAllCoroutines();
    }
}