using UnityEngine;

public abstract class EnemyMoveState : MonoBehaviour
{
    protected abstract void Update();
    protected abstract void GetDependencies();
}
