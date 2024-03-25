using ClassSound.Models;

namespace ClassSound.Menus;

internal class MenuRegisterAlbum : Menu
{
    public override void Execute(Dictionary<string, Band> bandList)
    {
        base.Execute(bandList);
        DisplayTitleOption("Register Album");
        DisplayCurrentList(bandList);
        Console.Write("Type the name of the band you want to register a new album: ");
        string bandNameToAlbum = Console.ReadLine()!;

        if (bandList.TryGetValue(bandNameToAlbum, out Band? currentBand))
        {
            DisplayCurrentList(currentBand.albumsList, true);
            Console.Write("Type the title of the album: ");
            string albumTitle = Console.ReadLine()!;
            currentBand.AddAlbum(new Album(albumTitle));
            Console.WriteLine($"The album {albumTitle} of the band {currentBand.Name} was registered with success");
            Thread.Sleep(2500);
            return;
        }

        ReturnMainTexts($"The band {bandNameToAlbum} was not found");
    }
}
