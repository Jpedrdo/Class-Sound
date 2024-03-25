using ClassSound.ChapGpt;
using ClassSound.Models;

namespace ClassSound.Menus;

internal class MenuRegisterBand : Menu
{
    public override async void Execute(Dictionary<string, Band> bandList)
    {
        base.Execute(bandList);
        DisplayTitleOption("Register Band");
        DisplayCurrentList(bandList);
        Console.Write("Type the name of the band: ");
        string bandName = Console.ReadLine()!;
        
        if (bandList.ContainsKey(bandName))
        {
            ReturnMainTexts($"The band {bandName} was already been added");
            return;
        }
        
        Band newBand = new(bandName)
        {
            Resume = await new ChatGpt().Execute(bandName)
        };

        bandList.Add(bandName, newBand);
        Console.WriteLine($"The band {bandName} was registered with success");
        Thread.Sleep(2500);
    }
}
