using ClassSound.Models;

namespace ClassSound.Menus;

internal class MenuEvaluateAlbum : Menu
{
    public override void Execute(Dictionary<string, Band> bandList)
    {
        base.Execute(bandList);
        DisplayTitleOption("Evaluate Album");
        DisplayCurrentList(bandList);
        Console.Write("Type the name of the band you want to evaluate the album: ");
        string bandNameEvaluateAlbum = Console.ReadLine()!;

        if (bandList.TryGetValue(bandNameEvaluateAlbum, out Band? currentBand))
        {
            List<Album> currentAlbumList = currentBand.albumsList;

            if (currentAlbumList.Count == 0)
            {
                ReturnMainTexts($"The band {bandNameEvaluateAlbum} don't have any albums added yet");
                return;
            }

            DisplayCurrentList(currentAlbumList, true);
            Console.Write("Now type the name of the album you want to evaluate: ");
            string albumName = Console.ReadLine()!;
            var currentAlbum = currentAlbumList.FirstOrDefault(x => x.Name.Equals(albumName));

            if (currentAlbum != null)
            {
                Console.Write($"What rating would you give to the {albumName}? ");

                Rate albumRating = Rate.Parse(Console.ReadLine()!);
                currentAlbum.AddRate(albumRating);
                Console.WriteLine($"The rating of {albumRating.RateValue} to the album {albumName} of the band {bandNameEvaluateAlbum} was given successfully");
                Thread.Sleep(2500);
                return;
            }

            ReturnMainTexts($"The album {albumName} of the band {bandNameEvaluateAlbum} was not found");
            return;
        }

        ReturnMainTexts($"The band {bandNameEvaluateAlbum} was not found");
    }
}
