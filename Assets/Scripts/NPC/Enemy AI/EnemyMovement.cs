using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameManager.Instance.GetPlayerTransform();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void Idle()
    {

    }
    private void Patrol()
    {

    }
    private void TargetPlayer()
    {

    }
}
