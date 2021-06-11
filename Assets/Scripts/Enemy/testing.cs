using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private WeaponBase weapon;

    private RepeatableTimer _timer;
    private bool flag = true;

    private void Awake()
    {
        _timer = new RepeatableTimer(5);
    }
    private void Update()
    {
        _timer.Tick(Time.deltaTime);

        if (_timer.IsReady())
        {
            animator.SetBool("Shoot",flag);
            flag = !flag;
        }
    }
}
