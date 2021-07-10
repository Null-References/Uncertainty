using UnityEngine;
using Utils;

namespace NPC
{
    public class WaspBotPool : PoolBase<WaspBot>
    {
        private int _count = 0;
        private int _alive = 0;
        private int _deathCount = 0;

        public int GetNumberOfAlive() => _alive;

        public override void ReturnToPool(WaspBot returnObject)
        {
            base.ReturnToPool(returnObject);
            _alive -= 1;
            _deathCount++;
            GameManager.Instance.SaveThis(_deathCount, "PlayerKillCount");
            int killScore = GameManager.Instance.LoadThis<int>("PlayerKillCount");
            Debug.Log(killScore);
        }

        public override WaspBot Get()
        {
            if (_objects.Count < 1)
            {
                AddToPool(1);
            }

            return _objects.Dequeue();
        }

        protected override void AddToPool(int count)
        {
            base.AddToPool(count);
            _count += count;
            _alive += count;
        }
    }
}