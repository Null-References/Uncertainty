using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [Range(0,180)]
    [SerializeField] private float radius = 30f;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothness=0.1f;

    private Vector3 _defaultForward;

    private void Start()
    {
        _defaultForward = transform.forward;
        if (!target)
        {
            Debug.Log($"Set target for Look at component On: {gameObject.name} ");
        }
    }
    private void Update()
    {
        if (!target) return;

        if (Vector3.Angle(target.position - transform.position, _defaultForward) < radius)
        {
            var direction = (target.position - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, direction, smoothness);
        }
        else
            transform.forward = Vector3.Lerp(transform.forward, _defaultForward, smoothness);
    }
}
