using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    [SerializeField] private Vector3 _offset;
    private Transform _target;
    private float _step;

    private void LateUpdate()
    {
        if (!_target) return;
        
        _step = _followSpeed * Vector2.Distance(_target.position, transform.position) * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, _target.position + _offset, _step);
    }

    public void SetTarget(Transform t)
    {
        _target = t;
    }
}
