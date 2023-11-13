using TheBattle.Entities;
using TheBattle.Entities.Fraction.Dire;
using TheBattle.Entities.Fraction.Radiant;

namespace TheBattle.Factories;

public class DireFactory:AbstractFactory
{
    public override Unit CreateHeal()
    {
        return new DireHeal(950, 80, 40);
    }

    public override Unit CreateMelee()
    {
        return new DireMelee(1550, 150,25,60);
    }

    public override Unit CreateRange()
    {
        return new DireRange(1200, 12,15,80,50);
    }
}