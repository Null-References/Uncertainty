using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetShooting()
    {
        animator.SetBool("Shoot", true);
    }
    public void SetIdle()
    {
        animator.SetBool("Shoot", false);
    }
}
