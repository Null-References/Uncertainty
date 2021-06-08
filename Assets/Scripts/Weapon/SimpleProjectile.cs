using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float lifeTime = 2f;
    
    private NonRepeatableTimer _timer;


    private void OnEnable()
    {
        _timer.ResetTimer();
    }
    private void Awake()
    {
        _timer = new NonRepeatableTimer(lifeTime);
        _timer.OnTimerEnded += DeSpawn;
    }
    private void Update()
    {
        _timer.Tick(Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void DeSpawn()
    {
        SimpleProjectilePool.Instance.ReturnToPool(this);
    }
}