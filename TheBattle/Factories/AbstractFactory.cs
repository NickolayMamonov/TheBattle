using TheBattle.Entities;

namespace TheBattle.Factories;

public abstract class AbstractFactory
{
    public abstract Unit CreateHeal();
    public abstract Unit CreateMelee();
    public abstract Unit CreateRange();

}