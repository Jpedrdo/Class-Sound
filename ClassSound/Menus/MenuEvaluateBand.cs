using ClassSound.Models;

namespace ClassSound.Menus;

internal class MenuEvaluateBand : Menu
{
    public override void Execute(Dictionary<string, Band> bandList)
    {
        base.Execute(bandList);
        DisplayTitleOption("Evaluate Band");
        DisplayCurrentList(bandList);
        Console.Write("Type the name of the band you want to evaluate: ");
        string bandNameEvaluate = Console.ReadLine()!;

        if (bandList.TryGetValue(bandNameEvaluate, out Band? currentBand))
        {
            Console.Write($"What rating would you give to the {bandNameEvaluate}? ");

            Rate bandRating = Rate.Parse(Console.ReadLine()!);
            currentBand.AddRate(bandRating);
            Console.WriteLine($"The rating of {bandRating.RateValue} to the band {bandNameEvaluate} was given successfully");
            Thread.Sleep(2500);
            return;
        }

        ReturnMainTexts($"The band {bandNameEvaluate} was not found");
    }
}
