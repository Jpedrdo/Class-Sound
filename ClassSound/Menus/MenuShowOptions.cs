using ClassSound.Models;

namespace ClassSound.Menus
{
    internal class MenuShowOptions : Menu
    {
        private static MenuShowOptions? instance = null;
        private static readonly object padlock = new();

        private protected static readonly List<string> optionsLabels = new()
        {
            "\nType 1 to register a band",
            "Type 2 to register a album",
            "Type 3 to display all bands",
            "Type 4 to evaluate a band",
            "Type 5 to evaluate a album",
            "Type 6 to display the details of a band",
            "Type -1 to exit"
        };
        private protected static readonly Dictionary<int, Menu> options = new()
        {
            { 1, new MenuRegisterBand() },
            { 2, new MenuRegisterAlbum() },
            { 3, new MenuShowRegisteredBands() },
            { 4, new MenuEvaluateBand() },
            { 5, new MenuEvaluateAlbum() },
            { 6, new MenuDetailsBand() },
            { -1, new MenuExit() }
        };

        public static MenuShowOptions Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new MenuShowOptions();
                    return instance;
                }
            }
        }

        static void ShowLogo()
        {
            Console.WriteLine(@"
▒█▀▀█ ▒█░░░ ░█▀▀█ ▒█▀▀▀█ ▒█▀▀▀█ 　 ▒█▀▀▀█ ▒█▀▀▀█ ▒█░▒█ ▒█▄░▒█ ▒█▀▀▄ 
▒█░░░ ▒█░░░ ▒█▄▄█ ░▀▀▀▄▄ ░▀▀▀▄▄ 　 ░▀▀▀▄▄ ▒█░░▒█ ▒█░▒█ ▒█▒█▒█ ▒█░▒█ 
▒█▄▄█ ▒█▄▄█ ▒█░▒█ ▒█▄▄▄█ ▒█▄▄▄█ 　 ▒█▄▄▄█ ▒█▄▄▄█ ░▀▄▄▀ ▒█░░▀█ ▒█▄▄▀
    ");
            Console.WriteLine("Welcome Class Sound");
        }

        private void MenuOptions(Dictionary<string, Band> bandList)
        {
            Console.Write("\nType your option: ");
            string chosenOption = Console.ReadLine()!;
            if (int.TryParse(chosenOption, out int chosenOptionNumber))
            {
                if (options.TryGetValue(chosenOptionNumber, out Menu? currentOption))
                {
                    currentOption.Execute(bandList);
                    if (chosenOptionNumber > 0) Execute(bandList);
                    return;
                }
            }
            Console.WriteLine(invalidOption);
        }

        public override void Execute(Dictionary<string, Band> bandList)
        {
            base.Execute(bandList);
            ShowLogo();
            foreach (var labels in optionsLabels)
            {
                Console.WriteLine(labels);
            }
            MenuOptions(bandList);
        }
    }
}
