using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveDataContainer : MonoBehaviour
{
    [SerializeField] public float speed = 2;
    [SerializeField] public float targetMinDistance = 9;
    [SerializeField] public List<Transform> pathPoints;
    [SerializeField] public float timeToNextPoint = 15f; //TODO : rename this thing
    [Range(0, 1)] public float rotationSmoothness = 0.1f;
    [Range(0, 1)] public float positionSmoothness = 0.1f;
}
