using ClassSound.Models;

namespace ClassSound.Menus;

internal class MenuDetailsBand : Menu
{
    public static string? TreatAlbumsText(List<Album> albums)
    {
        int currentAlbumCount = albums.Count;

        if (currentAlbumCount == 0) return "and no albums added yet";

        Console.WriteLine($" and also {currentAlbumCount} album{(currentAlbumCount == 1 ? null : "s")} added: ");

        string albumText = string.Empty;
        for (int i = 0; i < currentAlbumCount; i++)
        {
            Album currentAlbum = albums[i];
            string albumName = currentAlbum.Name;
            float albumAvarage = currentAlbum.NoteAvarage;

            if (albumAvarage > 0) albumName += $" ({albumAvarage} rate of avarage)";

            if (currentAlbumCount > 1)
            {
                if (i == currentAlbumCount - 1)
                {
                    albumText = $"{albumText.Remove(albumText.Length - 2)} and {albumName}";
                    break;
                }
                albumText += $"{albumName}, ";
            }
            else albumText = albumName;
        }

        return $"\n{albumText}";
    }

    public override void Execute(Dictionary<string, Band> bandList)
    {
        base.Execute(bandList);
        DisplayTitleOption("Details of a Band");
        DisplayCurrentList(bandList);
        Console.Write("Type the name of the band you want to know the details: ");
        string bandNameDetails = Console.ReadLine()!;

        if (bandList.TryGetValue(bandNameDetails, out Band? currentBand))
        {
            List<Album> currentAlbum = currentBand.albumsList;
            float currentAvarage = currentBand.NoteAvarage;
            string currentResume = currentBand.Resume ?? "";

            Console.Write($"\nThe band {bandNameDetails} ");
            if (currentAvarage > 0) Console.Write($"have a rate avarage of {currentBand.NoteAvarage}"); 
            else Console.Write($"don't have any rate");
            Console.Write($" {TreatAlbumsText(currentAlbum)}\n");

            if (!string.IsNullOrEmpty(currentResume)) Console.WriteLine($"\nResume: {currentResume}\n");

            ReturnMainTexts();
            return;
        }

        ReturnMainTexts($"The band {bandNameDetails} was not found");
    }
}
