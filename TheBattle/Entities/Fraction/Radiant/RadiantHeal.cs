using TheBattle.Entities.BaseCharacters;

namespace TheBattle.Entities.Fraction.Radiant;

public class RadiantHeal: Heal
{
    public RadiantHeal(int health,  int initiative, int healing) : base(health, initiative, healing)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(RadiantHeal)} делает ход");
        if (ProbabilityBy(Initiative)) TargetHeal(friendlyUnits[new Random().Next(0,friendlyUnits.Count - 1)]);
        else GroupHeal(friendlyUnits);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(RadiantHeal)} получил урон: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(RadiantHeal)} получил урон и умер");
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
                message = $"{nameof(RadiantHeal)} вылечил {unit.GetType().Name} на {Healing}";
            }
            else
            {
                unit.Health += valueIncrease;
                message = $"{nameof(RadiantHeal)} вылечил {unit.GetType().Name} на {valueIncrease}";
            }
        }
        else
        {
            message = $"{nameof(RadiantHeal)} испугался и не вылечил {unit.GetType().Name}";
        }
        Console.WriteLine(message);
    }

    public override void GroupHeal(List<Unit> units)
    {
        Console.WriteLine($"{nameof(RadiantHeal)} лечит всю команду");
        units.ForEach(TargetHeal);
    }
}