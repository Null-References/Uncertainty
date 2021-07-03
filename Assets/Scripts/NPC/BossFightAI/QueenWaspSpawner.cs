using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QueenWaspSpawner : MonoBehaviour
{
    [SerializeField] private int difficulty = 1;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private int maxAliveBots = 3;
    [SerializeField] private float spawnRate = 10f;
    [SerializeField] private List<Transform> pathPoints;

    private WaspBotPool _pool;
    private RepeatableTimer _timer;
    private int _currentBotCount = 0;
    private void Start()
    {
        _pool = WaspBotPool.Instance as WaspBotPool;
        _timer = new RepeatableTimer(spawnRate);
    }

    private void Update()
    {
        _timer.Tick(Time.deltaTime);

        if (_timer.IsReady())
            SpawnBot();
    }

    private void SpawnBot()
    {
        _currentBotCount = _pool.GetNumberOfAlive();
        if (_currentBotCount < maxAliveBots)
        {
            var newBot = WaspBotPool.Instance.Get();
            newBot.gameObject.SetActive(true);
            newBot.transform.position = spawnPosition.position;
            int portion = (pathPoints.Count / maxAliveBots);
            var botPointPortion = pathPoints.GetRange(_currentBotCount%pathPoints.Count * portion, portion); // TODO : fix out of range and null refrence problem
            newBot.SetPathPoints(botPointPortion);
        }
    }

    public void ReduceAliveCount()
    {
        _currentBotCount--;
    }
}
