namespace ClassSound.Models;

internal class Band : RateClass, IRateable
{
    public Band(string bandName) => Name = bandName;
    public string Name { get; }
    public string? Resume { get; set; }
    public List<Album> albumsList = new();

    public void AddAlbum(Album newAlbum) => albumsList.Add(newAlbum);

    public void ShowDiscography()
    {
        Console.WriteLine($"\nShow discography of band: {Name}\n");
        foreach (Album album in albumsList)
        {
            Console.WriteLine($"Album: {album.Name}");
        }
    }
}
