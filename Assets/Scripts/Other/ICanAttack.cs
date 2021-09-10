using Units;

public interface ICanAttack
{
    float AttackRange { get; }
    float Power { get; }
    void Attack(IHealthContainer target);
}