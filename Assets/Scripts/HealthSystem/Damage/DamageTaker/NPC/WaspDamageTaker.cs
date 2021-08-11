using HealthSystem.Damage.DamageDealer;
using HealthSystem.HealthSys;

namespace HealthSystem.Damage.DamageTaker.NPC
{
    public class WaspDamageTaker 
    {
        private IHealth _health;

        public WaspDamageTaker(IHealth health)
        {
            _health = health;
        }
        public void Process(IDamageStats damageStats)
        {
            throw new System.NotImplementedException();
        }
    }
}
