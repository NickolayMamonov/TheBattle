using TheBattle.Factories;

namespace TheBattle;

public class Map
{
    public enum MapEnum
    {
        Radiant = 1,
        Dire = 2
    }

    public AbstractFactory? GetFactoryMap(MapEnum map)
    {
        AbstractFactory? result = null;
        switch (map)
        {
            case MapEnum.Radiant:
            {
                result = new RadiantFactory();
                break;
            }
            case MapEnum.Dire:
            {
                result = new DireFactory();
                break;
            }
            
        }

        return result;
    }
}