﻿using UnityEngine;

[RequireComponent(typeof(EnemyMoveDataContainer))]
public class EnemyChase : EnemyMoveState
{
    private float _speed;
    private float _targetMinDistance;
    private float _rotationSmoothness;
    private Transform _player;
    private void Start()
    {
        GetDependencies();

        _player = GameManager.Instance.GetPlayerTransform();
    }
    protected override void Update()
    {
        ChasePlayer();
    }
    private void ChasePlayer()
    {
        var direction = _player.position - transform.position;
        if (direction.sqrMagnitude < _targetMinDistance)//note: this is squered not actual distance
            transform.Translate(-direction.normalized * _speed * Time.deltaTime);
        else
            transform.Translate(direction.normalized * _speed * Time.deltaTime);
        
        var targetRotation = Quaternion.LookRotation(_player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSmoothness);
    }
    protected override void GetDependencies()
    {
        var data = GetComponent<EnemyMoveDataContainer>();
        if (!data)
        {
            Debug.Log($"Add enemy move data container to : {gameObject.name} ");
            return;
        }
        _speed = data.speed;
        _rotationSmoothness = data.rotationSmoothness;
    }
}