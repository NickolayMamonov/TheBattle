using Range = TheBattle.Entities.BaseCharacters.Range;

namespace TheBattle.Entities.Fraction.Radiant;

public class RadiantRange: Range
{
    public RadiantRange(int health, int ammunition, int agility, int damage, int initiative) : base(health, ammunition, agility, damage, initiative)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(RadiantRange)} делает ход");
        Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(RadiantRange)} получил урон: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(RadiantRange)} получил урон и умер");
        }
    }

    public override void Attack(Unit unit)
    {
        if (Ammunition > 0)
        {
            Console.WriteLine($"{nameof(RadiantRange)} атакует");
            unit.TakeAttack(Damage);
        }
        else
        {
            Console.WriteLine($"{nameof(RadiantRange)} закончились снаряды");
        }
        
    }
}