using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> pathPoints;
    [SerializeField] private float timePeriod = 15f;
    [Range(0, 1)] [SerializeField] private float rotationSmoothness = 0.1f;
    [Range(0, 1)] [SerializeField] private float positionSmoothness = 0.1f;
    [SerializeField] private Animator animator;
    [SerializeField] private float radius = 5f;

    private Transform _player;
    private RepeatableTimer _timer;
    private Transform _currentPoint;
    private int _state = 0;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameManager.Instance.GetPlayerTransform();
        _currentPoint = transform;
        _timer = new RepeatableTimer(timePeriod);
    }

    // Update is called once per frame
    void Update()
    {
        _timer.Tick(Time.deltaTime);
        switch (_state)
        {
            case 0:
                Idle();
                break;
            case 1:
                Patrol();
                break;
            case 2:
                ChasePlayer();
                break;
        }
    }

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

    private void SetIdleAnimation() => animator.SetBool("Shoot", false);

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
        if (Vector3.Distance(_player.position, transform.position) > radius)
        {
            transform.position = Vector3.Lerp(transform.position, _player.position, positionSmoothness);
            var targetRotation = Quaternion.LookRotation(_player.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSmoothness);
        }
        //TODO: WORKS FINE BUT REFACTOR & COMPLETE THE "ELSE" & CHANGE EVERYTHING :)))))))))))
    }

    public void SetState(int state) => this._state = state;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}