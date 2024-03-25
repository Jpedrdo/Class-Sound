using ClassSound.Models;

namespace ClassSound.Menus;

internal class MenuShowRegisteredBands : Menu
{
    public override void Execute(Dictionary<string, Band> bandList)
    {
        base.Execute(bandList);
        DisplayTitleOption("Displaying all the bands");
        foreach (string band in bandList.Keys)
        {
            Console.WriteLine($"Band: {band}");
        };
        ReturnMainTexts();
    }
}
