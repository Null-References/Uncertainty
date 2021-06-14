using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> pathPoints;
    [SerializeField] private float timePeriod = 15f;
    [Range(0,1)]
    [SerializeField] private float smoothness = 0.1f;
    [SerializeField] private Animator animator;

    private Transform _player;
    private RepeatableTimer _timer;
    private Transform _currentPoint;

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
        Idle();
    }

    private void Idle()
    {
        SetIdleAnimation();
        if (_timer.IsReady())
        {
            var pointCount = pathPoints.Count;
            var rand = Random.Range(0, pointCount - 1);
            var selectedPoint = pathPoints[rand];
            _currentPoint = selectedPoint;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _currentPoint.rotation, smoothness);
    }

    private void SetIdleAnimation()
    {
        animator.SetBool("Shoot", false);
    }

    private void Patrol()
    {
    }

    private void TargetPlayer()
    {
    }
}