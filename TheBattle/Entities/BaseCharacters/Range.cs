namespace TheBattle.Entities.BaseCharacters;

public abstract class Range:Unit
{
    public int Ammunition { get; set; }
    public int Agility { get; set; }
    public int Damage { get; set; }
    protected Range(int health,int ammunition,int agility,int damage, int initiative) : base(health,  initiative)
    {
        Ammunition = ammunition;
        Agility = agility;
        Damage = damage;
    }
    public abstract void Attack(Unit unit);
}