using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CosineRenderer : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _amplitude = 0.5f;
    [SerializeField] private float _frequency = 1f;

    private float Evaluate(float x)
    {
        return Mathf.Cos(x * _frequency) * _amplitude;
    }
}
