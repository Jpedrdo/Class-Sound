using ClassSound.Models;

namespace ClassSound.Menus;

internal class Menu
{
    readonly public string invalidOption = "Invalid input";

    public static void DisplayTitleOption(string title)
    {
        string asterisks = string.Empty.PadLeft(title.Length, '*');
        Console.WriteLine($"{asterisks}\n{title}\n{asterisks}\n");
    }

    public static void DisplayCurrentList<T>(IEnumerable<T> list, bool? jumpLine = false)
    {
        if (list.Any())
        {
            string finalList = "";
            int index = 0;

            if (jumpLine == true) Console.Write("\n");

            foreach (var item in list)
            {
                Type type = item!.GetType();
                string output = "";
                if (type == typeof(KeyValuePair<string, Band>))
                {
                    var band = (KeyValuePair<string, Band>)Convert.ChangeType(item, typeof(KeyValuePair<string, Band>));
                    output = band.Key;
                }
                else if (type == typeof(Album))
                {
                    var album = (Album)Convert.ChangeType(item, typeof(Album));
                    output = album.Name!;
                }
                finalList += index > 0 ? $", {output}" : $"Current {(type == typeof(KeyValuePair<string, Band>) ? "band's" : "album's")} added so far: {output}";
                if (index == 0) index++;
            }
            Console.WriteLine($"{finalList}\n");
        }
    }

    public static void ReturnMainTexts(string? msg = null)
    {
        if (!string.IsNullOrEmpty(msg))
        {
            Console.WriteLine($"\n{msg}");
        }
        Console.WriteLine("\nType anything to return to main menu");
        Console.ReadKey();
    }

    public virtual void Execute(Dictionary<string, Band> bandList)
    {
        Console.Clear();
    }
}
