using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class NormalBullet : MonoBehaviour, IProjectile
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private LayerMask whatIsCollidable;

    private int _owner;
    private NonRepeatableTimer _timer;
    private DamageDealer _dealer;

    private void OnEnable() => _timer.ResetTimer();

    private void Awake()
    {
        _timer = new NonRepeatableTimer(lifeTime);
        _timer.OnTimerEnded += DeSpawn;
    }

    private void Start() => _dealer = GetComponent<DamageDealer>();

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{other.name} : {other.GetInstanceID()}");
        if (_owner == other.GetInstanceID())
            return;

        if ((whatIsCollidable.value & (1 << other.gameObject.layer)) <= 0)
            return;

        var target = other.GetComponents<ITakeDamage>();
        if (target.Length <= 0)
            return;

        foreach (var taker in target)
        {
            taker.TakeDamage(_dealer.DamageTypes);
        }

        DeSpawn();
    }

    private void Update()
    {
        _timer.Tick(Time.deltaTime);
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }
    public void SetOwner(int ownerID)
    {
        _owner = ownerID;
    }
    private void DeSpawn() => NormalBulletPool.Instance.ReturnToPool(this);
}