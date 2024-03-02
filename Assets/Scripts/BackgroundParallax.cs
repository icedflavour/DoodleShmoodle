using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public float speed;
    public float shiftDistance = 10.5f;
    private Camera _mainCamera;
    
    private void Start()
    {
        _mainCamera = GetComponentInParent<Camera>();
    }
    private void Update()
    {
        var transformPosition = transform.position;
        transformPosition.y -= speed * Time.deltaTime;
        if (transformPosition.y - _mainCamera.transform.position.y <= -shiftDistance)
        {
            transformPosition.y = _mainCamera.transform.position.y;
        }

        transform.position = transformPosition;
    }
}
