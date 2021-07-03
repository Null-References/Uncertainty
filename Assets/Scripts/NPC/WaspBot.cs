using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this class handles bots needs and sets diffrent dependencies for weapons and stuff
/// </summary>
[RequireComponent(typeof(EnemyMoveDataContainer))]
public class WaspBot : MonoBehaviour
{
    private EnemyMoveDataContainer _container;
    private void OnEnable()
    {
        if (_container == null)
        {
            _container = GetComponent<EnemyMoveDataContainer>();
        }
    }
    public void SetPathPoints(List<Transform> points)
    {
        _container.pathPoints = points;
    }
    public void SetSpeed(float speed)
    {
        _container.speed = speed;
    }
}
