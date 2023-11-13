using TheBattle.Entities;
using TheBattle.Entities.Fraction.Radiant;

namespace TheBattle.Factories;

public class RadiantFactory: AbstractFactory
{
    public override Unit CreateHeal()
    {
        return new RadiantHeal(900, 80, 35);
    }

    public override Unit CreateMelee()
    {
        return new RadiantMelee(1500, 135,22,60);
    }

    public override Unit CreateRange()
    {
        return new RadiantRange(1150, 10,15,95,50);
    }
}