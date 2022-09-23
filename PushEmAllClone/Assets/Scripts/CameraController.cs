using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float _lerpTime;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - playerTransform.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 _newPos = Vector3.Lerp(transform.position, playerTransform.position + _offset, _lerpTime * Time.deltaTime);
        transform.position = _newPos;
    }
}
