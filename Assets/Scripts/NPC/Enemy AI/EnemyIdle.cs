using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMoveDataContainer))]
public class EnemyIdle : EnemyMoveState
{
    private float _timeToNextPoint;
    private float _rotationSmoothness;
    private List<Transform> _pathPoints;

    private RepeatableTimer _timer;
    private Transform _currentPoint;
    
    private void Start()
    {
        GetDependencies();

        _currentPoint = _pathPoints[0];
        _timer = new RepeatableTimer(_timeToNextPoint);
    }
    protected override void Update()
    {
        _timer.Tick(Time.deltaTime);
        Idle();
    }
    private void Idle()
    {
        if (_timer.IsReady())
        {
            var pointCount = _pathPoints.Count;
            var rand = Random.Range(0, pointCount - 1);
            var selectedPoint = _pathPoints[rand];
            _currentPoint = selectedPoint;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _currentPoint.rotation, _rotationSmoothness);// TODO : maybe here need * time.deltatime cant think right now
    }

    protected override void GetDependencies()
    {
        var data = GetComponent<EnemyMoveDataContainer>();
        if (!data)
        {
            Debug.Log($"Add enemy move data container to : {gameObject.name} ");
            return;
        }
        _timeToNextPoint = data.timeToNextPoint;
        _rotationSmoothness = data.rotationSmoothness;
        _pathPoints = data.pathPoints;
    }
}
