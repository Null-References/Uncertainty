using System.Collections.Generic;
using Timer;
using UnityEngine;

namespace NPC.Enemy_AI
{
    [RequireComponent(typeof(EnemyMoveDataContainer))]
    public class EnemyIdle : EnemyMoveState
    {
        private float _timeToNextPoint;
        private float _rotationSmoothness;
        private List<Transform> _pathPoints;

        private RepeatableTimer _timer;
        private Transform _currentPoint;

        private void OnEnable() => GetDependencies();

        private void Start() => _timer = new RepeatableTimer(_timeToNextPoint);

        protected override void Update()
        {
            _timer.Tick(Time.deltaTime);

            if (_currentPoint == null || _pathPoints == null || _pathPoints.Count == 0)
            {
                GetDependencies();
                return;
            }

            Idle();
        }

        private void Idle()
        {
            if (_timer.IsReady())
            {
                GetRandomPoint();
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _currentPoint.rotation,
                _rotationSmoothness * Time.deltaTime);
        }

        private void GetRandomPoint()
        {
            var pointCount = _pathPoints.Count;
            var rand = Random.Range(0, pointCount - 1);
            var selectedPoint = _pathPoints[rand];
            _currentPoint = selectedPoint;
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
            if (_pathPoints.Count != 0)
                GetRandomPoint();
        }
    }
}