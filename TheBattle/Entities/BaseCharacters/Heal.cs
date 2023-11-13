namespace TheBattle.Entities.BaseCharacters;

public abstract class Heal: Unit
{
    public int Healing { get; set; }
    protected Heal(int health, int initiative,int healing) : base(health,  initiative)
    {
        Healing = healing;
    }
    public abstract void TargetHeal(Unit unit);
    public abstract void GroupHeal(List<Unit> units);
}