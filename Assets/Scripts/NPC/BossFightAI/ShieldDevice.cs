using Timer;
using UnityEngine;
using UnityEngine.Events;

namespace NPC.BossFightAI
{
    public class ShieldDevice : MonoBehaviour
    {
        [SerializeField] private GameObject particle;
        [SerializeField] private Collider deviceCollider;
        [SerializeField] private float repairTime = 20f;
        [SerializeField] private UnityEvent OnRepair;

        private bool _isBroken = false;
        private RepeatableTimer _timer;

        private void Start() => _timer = new RepeatableTimer(repairTime);

        private void Update()
        {
            if (_isBroken)
            {
                _timer.Tick(Time.deltaTime);
                if (_timer.IsReady())
                {
                    RepairDevice();
                }
            }
        }

        public bool IsBroken() => _isBroken;

        public void BreakDevice()
        {
            particle.SetActive(false);
            _isBroken = true;
            deviceCollider.enabled = false;
        }

        private void RepairDevice()
        {
            particle.SetActive(true);
            _isBroken = false;
            OnRepair.Invoke();
            deviceCollider.enabled = true;
        }
    }
}