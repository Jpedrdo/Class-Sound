namespace ClassSound.Models;

internal class Music
{
    public Music(Band artist, string musicName)
    {
        Artist = artist;
        Name = musicName;
    }
    public string Name { get; }
    public Band Artist { get; }
    public string Title => $"The music {Name} is from the artist {Artist}";
    public int Duration { get; set; }
    public bool Available { get; set; }

    public void ShowDatasheet()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Atirst: {Artist.Name}");
        Console.WriteLine($"Duration: {Duration}");
        if (Available)
        {
            Console.WriteLine("Available on plan");
            return;
        }
        Console.WriteLine("Get a vip plan");
    }
}
