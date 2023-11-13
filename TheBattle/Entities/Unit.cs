namespace TheBattle.Entities;

public abstract class Unit
{
    public int MaxHealth { get; set; }
    public int Health { get; set; }
   
    public int Initiative { get; set; }
    
    protected Unit(int health, int initiative)
    {
        Health = health;
        MaxHealth = health;
       
        Initiative = initiative;
    }

    public abstract void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits);

    protected bool ProbabilityBy(int value) => new Random().Next(1, 101) <= value;

    public virtual void TakeAttack(int valueDamage)
    {
        Health -= valueDamage;
    }
}