using Units;

public interface IDamageDealer
{
    float Power { get; }
    IHealthContainer Target { get; }
    void DealDamage();
}