using System.Collections.Generic;
using NPC.Enemy_AI.StateMachine.Conditions;
using UnityEngine;

namespace NPC.Enemy_AI
{
    [RequireComponent(typeof(EnemyMoveDataContainer), typeof(ReachDestination))]
    public class EnemyPatrol : EnemyMoveState
    {
        private float _rotationSmoothness;
        private float _speed;
        private List<Transform> _pathPoints;
        private ReachDestination _destinationCondition;
        private Transform _currentPoint;

        private void OnEnable()
        {
            GetDependencies();
            if (_pathPoints == null) return;
            if (!_destinationCondition) return;

            GetRandomPoint();
            _destinationCondition.SetDestination(_currentPoint.position);
        }

        private void GetRandomPoint()
        {
            var pointCount = _pathPoints.Count;
            var rand = Random.Range(0, pointCount - 1);
            var selectedPoint = _pathPoints[rand];
            _currentPoint = selectedPoint;
        }

        private void Start()
        {
            _destinationCondition = GetComponent<ReachDestination>();
            _destinationCondition.SetDestination(_currentPoint.position);
        }

        protected override void Update()
        {
            if (_pathPoints == null || _pathPoints.Count == 0)
            {
                GetDependencies();
                return;
            }

            Patrol();
        }

        private void Patrol()
        {
            var direction = _currentPoint.position - transform.position;
            //vector.up is a little hard coded 
            if (
                direction.sqrMagnitude >
                1) //TODO: hardcode this is for when position is close to point it dosnt get throgh it and doesnt glitches
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up),
                    _rotationSmoothness);
                transform.position += direction.normalized * (_speed * Time.deltaTime);
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
            if (_pathPoints.Count != 0)
                GetRandomPoint();
        }
    }
}