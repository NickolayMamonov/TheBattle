using TheBattle.Entities.BaseCharacters;

namespace TheBattle.Entities.Fraction.Radiant;

public class RadiantMelee: Melee 
{
    public RadiantMelee(int health, int damage, int strength, int initiative) : base(health, damage, strength, initiative)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(RadiantMelee)} делает ход");
        Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(RadiantMelee)} получил урон: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(RadiantMelee)} получил урон и умер");
        }
    }

    public override void Attack(Unit unit)
    {
        
        Console.WriteLine($"{nameof(RadiantMelee)} атакует");
        unit.TakeAttack(Damage);
    }

    public override void CriticalAttack(Unit unit)
    {
        Console.WriteLine($"{nameof(RadiantMelee)} атакует");
        unit.TakeAttack(Damage*2);
    }
}