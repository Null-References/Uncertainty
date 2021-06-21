using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMoveDataContainer),typeof(ReachDestination))]
public class EnemyPatrol : EnemyMoveState
{
    private float _rotationSmoothness;
    private float _speed;
    private List<Transform> _pathPoints;
    private ReachDestination _destinationCondition;
    private Transform _currentPoint;

    private void OnEnable()
    {
        if (_pathPoints == null) return;
        if (!_destinationCondition) return;

        var pointCount = _pathPoints.Count;
        var rand = Random.Range(0, pointCount - 1);
        var selectedPoint = _pathPoints[rand];
        _currentPoint = selectedPoint;
        _destinationCondition.SetDestination(_currentPoint.position);
    }
    private void Start()
    {
        GetDependencies();

        _destinationCondition = GetComponent<ReachDestination>();
        _currentPoint = _pathPoints[0];
        _destinationCondition.SetDestination(_currentPoint.position);

    }
    protected override void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        var direction = _currentPoint.position - transform.position;
                                                                                                            //vector.up is a little hard coded 
        if (direction.sqrMagnitude > 1) //TODO: hardcode this is for when position is close to point it dosnt get throgh it and doesnt glitches
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(direction,Vector3.up), _rotationSmoothness);
            transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
        }
        else
            transform.rotation = Quaternion.Lerp(transform.rotation, _currentPoint.rotation, _rotationSmoothness);
    }
    protected override void GetDependencies()
    {
        var data = GetComponent<EnemyMoveDataContainer>();
        if (!data)
        {
            Debug.Log($"Add enemy move data container to : {gameObject.name} ");
            return;
        }
        _speed = data.speed;
        _rotationSmoothness = data.rotationSmoothness;
        _pathPoints = data.pathPoints;
    }
}
