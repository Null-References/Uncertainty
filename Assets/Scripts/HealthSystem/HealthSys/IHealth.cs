namespace HealthSystem.HealthSys
{
    public interface IHealth
    {
        float MaxHealth { get; }
        float CurrentHealth { get; set; }
        float MaxShield { get; }
        float CurrentShield { get; set; }
    }

}