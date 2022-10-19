using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 Offset;
    [SerializeField] private Transform Target;
    [SerializeField] private float SmoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

   void Awake()
    {
        Offset = transform.position - Target.position;
    }

    void LateUpdate()
    {

        Vector3 targetPosition = Target.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, SmoothTime);

    }
}
