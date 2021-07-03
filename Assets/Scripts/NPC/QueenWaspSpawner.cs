using System.Collections.Generic;
using UnityEngine;

public class QueenWaspSpawner : MonoBehaviour
{
    [SerializeField] private int difficulty = 1;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private int maxAliveBots = 5;
    [SerializeField] private float spawnRate = 10f;
    [SerializeField] private List<Transform> pathPoints;

    private RepeatableTimer _timer;
    private int _currentBotCount = 0;
    private void Start()
    {
        _timer = new RepeatableTimer(spawnRate);
    }

    private void Update()
    {
        _timer.Tick(Time.deltaTime);
        if (_currentBotCount < maxAliveBots)
        {
            if (_timer.IsReady())
            {
                var newBot = WaspBotPool.Instance.Get();
                newBot.gameObject.SetActive(true);
                newBot.transform.position = spawnPosition.position;
                newBot.SetPathPoints(pathPoints);
                _currentBotCount++;
            }
        }
    }
}
