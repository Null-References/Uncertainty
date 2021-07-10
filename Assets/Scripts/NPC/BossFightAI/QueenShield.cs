using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC.BossFightAI
{
    public class QueenShield : MonoBehaviour
    {
        [SerializeField] private Collider shieldCollider;
        [SerializeField] private List<ShieldDevice> devices;
        [SerializeField] private MeshRenderer shieldRenderer;
        [SerializeField] private float maxAlpha = .2f;

        private int _intactDevices;
        private float _currentAlpha = 0f;

        private void Start() => _intactDevices = devices.Count;

        public void BreakDevice()
        {
            _intactDevices -= 1;
            if (_intactDevices <= 0)
            {
                shieldCollider.enabled = false;
                shieldRenderer.enabled = false;
            }
        }

        public void RepairDevice()
        {
            _intactDevices += 1;
            shieldCollider.enabled = true;
            shieldRenderer.enabled = true;
        }

        public void HitEffect() => StartCoroutine(ChangeEffect());

        private IEnumerator ChangeEffect()
        {
            var material = shieldRenderer.material;
            var lastColor = material.color;
            lastColor.a = maxAlpha;
            material.color = lastColor;
            yield return new WaitForSeconds(0.1f);
            lastColor.a = 0;
            material.color = lastColor;
        }
    }
}
