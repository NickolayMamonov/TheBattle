using TheBattle;
using TheBattle.Entities;

public class Program
{
    private static void Main(string[] args)
    {
        
        var radiantFactory = new Map().GetFactoryMap(Map.MapEnum.Radiant);
        var direFactory = new Map().GetFactoryMap(Map.MapEnum.Dire);

        var teamRadiant= new List<Unit> {radiantFactory?.CreateHeal(), radiantFactory?.CreateMelee(),radiantFactory?.CreateMelee(), radiantFactory?.CreateRange(),radiantFactory?.CreateRange()};
        var teamDire = new List<Unit> {direFactory?.CreateHeal(), direFactory?.CreateMelee(), direFactory?.CreateRange(),direFactory?.CreateMelee(), direFactory?.CreateRange()};
        BattleSimulation(teamRadiant, teamDire);

    }

    private static void BattleSimulation(List<Unit> teamRadiant, List<Unit> teamDire)
    {

        teamRadiant.Sort((x, y) => x.Initiative.CompareTo(y.Initiative));
        teamDire.Sort((x, y) => x.Initiative.CompareTo(y.Initiative));
            
        var iteratorRadiant = 0;
        var iteratorDire = 0;
        var condition = teamRadiant.Count > 0 && teamDire.Count > 0;
        for (int i = 0; condition; i++)
        {
            if (i % 2 == 0)
            {
                teamRadiant[iteratorRadiant % teamRadiant.Count].Run(teamDire, teamRadiant);
                CheckCountTeam(teamDire);
                iteratorDire++;
            }
            else
            {
                teamDire[iteratorRadiant % teamDire.Count].Run(teamRadiant, teamDire);
                CheckCountTeam(teamDire);
                iteratorDire++;
            }

            if (teamDire.Count == 0 || teamRadiant.Count == 0)
            {
                break;
            }
        }

        string message;
        if (teamRadiant.Count > 0)
        {
            message = "Radiant Win!";
        }
        else
        {
            message = "Dire Win!";
        }
        Console.WriteLine(message);
    }
    private static void CheckCountTeam(List<Unit> units)
    {
        units.RemoveAll(e => e.Health <= 0);
    }
}