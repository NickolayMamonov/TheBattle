namespace TheBattle.Entities.BaseCharacters;

public abstract class Melee:Unit
{
    public int Damage { get; set; }
    public int Strength { get; set; }
    
    protected Melee(int health,int damage,int strength, int initiative) : base(health, initiative)
    {
        Damage = damage;
        Strength = strength;
    }

    public abstract void Attack(Unit unit);
    public abstract void CriticalAttack(Unit unit);
}