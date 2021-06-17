using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> pathPoints;
    [SerializeField] private float timePeriod = 15f;
    [Range(0, 1)] [SerializeField] private float rotationSmoothness = 0.1f;
    [Range(0, 1)] [SerializeField] private float positionSmoothness = 0.1f;

    private Transform _player;
    private RepeatableTimer _timer;
    private Transform _currentPoint;

    private void Start()
    {
        _player = GameManager.Instance.GetPlayerTransform();
        _currentPoint = transform;
        _timer = new RepeatableTimer(timePeriod);
    }

    private void Update() => _timer.Tick(Time.deltaTime);


    private void Idle()
    {
        if (_timer.IsReady())
        {
            var pointCount = pathPoints.Count;
            var rand = Random.Range(0, pointCount - 1);
            var selectedPoint = pathPoints[rand];
            _currentPoint = selectedPoint;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _currentPoint.rotation, rotationSmoothness);
    }

    private void Patrol()
    {
        if (_timer.IsReady())
        {
            var pointCount = pathPoints.Count;
            var rand = Random.Range(0, pointCount - 1);
            var selectedPoint = pathPoints[rand];
            _currentPoint = selectedPoint;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _currentPoint.rotation, rotationSmoothness);
        transform.position = Vector3.Lerp(transform.position, _currentPoint.position, positionSmoothness);
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.Lerp(transform.position,
            transform.position + ((_player.position - transform.position).normalized * speed), positionSmoothness);
        var targetRotation = Quaternion.LookRotation(_player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSmoothness);
        //TODO: WORKS FINE BUT REFACTOR & COMPLETE THE "ELSE" & CHANGE EVERYTHING :)))))))))))
    }
}