using ClassSound.Models;

namespace ClassSound.Menus;

internal class MenuExit : Menu
{
    public override void Execute(Dictionary<string, Band> bandList)
    {
        Console.WriteLine("\nBye Bye :)");
    }
}
