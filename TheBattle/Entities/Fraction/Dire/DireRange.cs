using Range = TheBattle.Entities.BaseCharacters.Range;

namespace TheBattle.Entities.Fraction.Dire;

public class DireRange: Range
{
    public DireRange(int health, int ammunition, int agility, int damage, int initiative) : base(health, ammunition, agility, damage, initiative)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(DireRange)} делает ход");
        Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(DireRange)} получил урон: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(DireRange)} получил урон и умер");
        }
    }

    public override void Attack(Unit unit)
    {
        if (Ammunition > 0)
        {
            Console.WriteLine($"{nameof(DireRange)} атакует");
            unit.TakeAttack(Damage);
        }
        else
        {
            Console.WriteLine($"{nameof(DireRange)} закончились снаряды");
        }
        
    }
}

