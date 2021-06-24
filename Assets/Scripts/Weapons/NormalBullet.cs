using System;
using UnityEngine;

public class NormalBullet : MonoBehaviour, IProjectile
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private LayerMask whatIsCollidable;

    private NonRepeatableTimer _timer;


    private void OnEnable() => _timer.ResetTimer();

    private void Awake()
    {
        _timer = new NonRepeatableTimer(lifeTime);
        _timer.OnTimerEnded += DeSpawn;
    }

    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other);
    }

    private void Update()
    {
        _timer.Tick(Time.deltaTime);
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }

    private void DeSpawn() => SimpleProjectilePool.Instance.ReturnToPool(this);
    public void DealDamage(Collider other)
    {
        
    }
}