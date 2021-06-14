using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    [SerializeField] private Transform shotPoint;
    [SerializeField] private WeaponBase weapon;
    [SerializeField] private Animator animator;
    
    private Transform _player;

    private void Start()
    {
        _player = GameManager.Instance.GetPlayerTransform();
    }
    private void Update()
    {
        shotPoint.LookAt(_player.position);
        weapon.Shoot();
    }

    public void SetShootingAnimation()
    {
        animator.SetBool("Shoot", true);
    }
    
}
