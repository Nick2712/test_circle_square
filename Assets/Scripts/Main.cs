using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject _circle;
    [SerializeField] private GameObject _square;
    [SerializeField] private int _scaleCoefficient;
    private int _currentScaleCoefficient;

    // Start is called before the first frame update
    void Start()
    {
        _square.transform.position = Vector3.zero;
        _circle.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentScaleCoefficient != _scaleCoefficient)
        {
            _currentScaleCoefficient = _scaleCoefficient;
            MakeScale();
        }
    }

    private void MakeScale()
    {
        _circle.transform.localScale = Vector3.one;
        _square.transform.localScale = Vector3.one;
        float circleScaleCoefficient = (Mathf.Sqrt(_scaleCoefficient * _scaleCoefficient * 2));
        _circle.transform.localScale *= circleScaleCoefficient;
        _square.transform.localScale *= _scaleCoefficient;
    }
}
