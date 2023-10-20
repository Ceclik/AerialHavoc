using System;
using UnityEngine;

public class KukinMover : MonoBehaviour
{
    private Transform _path;
    private Transform[] _points;
    private int _currentPoint;
    [SerializeField] private float kukinSpeed;

    private void Start()
    {
        _path = GameObject.Find("PathOfKukin").GetComponent<Transform>();
        _points = new Transform[_path.childCount];
        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);
        _currentPoint = 0;
    }

    private void FixedUpdate()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, kukinSpeed * Time.deltaTime);
        if (transform.position == target.position && _currentPoint < _points.Length)
            _currentPoint++;
        if (_currentPoint == _points.Length)
            _currentPoint = 0;
    }
}
