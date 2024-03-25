namespace ClassSound.Models;

internal class Album : RateClass, IRateable
{
    public Album(string albumName) => Name = albumName;
    private readonly List<Music> musicList = new();
    public string Name { get; }
    public int TotalDuration => musicList.Sum(x => x.Duration);

    public void AddMusic(Music newMusic) => musicList.Add(newMusic);

    public void DisplayMusics()
    {
        Console.WriteLine($"List of the musics of the album: {Name}\n");
        foreach (var music in musicList)
        {
            Console.WriteLine(music.Name);
        }
        Console.WriteLine($"\nTo be able to listen to all musics in the album you will need: {TotalDuration / 60} minutes");
    }
}
