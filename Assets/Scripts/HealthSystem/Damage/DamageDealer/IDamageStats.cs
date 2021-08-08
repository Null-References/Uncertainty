namespace HealthSystem.Damage.DamageDealer
{
    public interface IDamageStats
    {
        float BaseDamage { get; }
        float HeatDamage { get; }
        float ShockDamage { get; }
    }
}