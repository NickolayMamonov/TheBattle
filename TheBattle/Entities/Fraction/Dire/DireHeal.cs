using TheBattle.Entities.BaseCharacters;
using TheBattle.Entities.Fraction.Radiant;

namespace TheBattle.Entities.Fraction.Dire;

public class DireHeal:Heal
{
    public DireHeal(int health, int initiative, int healing) : base(health, initiative, healing)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(DireHeal)} делает ход");
        if (ProbabilityBy(Initiative)) TargetHeal(friendlyUnits[new Random().Next(0,friendlyUnits.Count - 1)]);
        else GroupHeal(friendlyUnits);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(DireHeal)} получил урон: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(DireHeal)} получил урон и умер");
        }
    }

    public override void TargetHeal(Unit unit)
    {
        string message;
        if (ProbabilityBy(Initiative))
        {
            var valueIncrease = unit.MaxHealth - unit.Health;
            if (valueIncrease >= Healing)
            {
                unit.Health += Healing;
                message = $"{nameof(DireHeal)} вылечил {unit.GetType().Name} на {Healing}";
            }
            else
            {
                unit.Health += valueIncrease;
                message = $"{nameof(DireHeal)} вылечил {unit.GetType().Name} на {valueIncrease}";
            }
        }
        else
        {
            message = $"{nameof(DireHeal)} испугался и не вылечил {unit.GetType().Name}";
        }
        Console.WriteLine(message);
    }

    public override void GroupHeal(List<Unit> units)
    {
        Console.WriteLine($"{nameof(DireHeal)} лечит всю команду");
        units.ForEach(TargetHeal);
    }

    
}