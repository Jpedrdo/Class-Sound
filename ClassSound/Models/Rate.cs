namespace ClassSound.Models;

internal class Rate
{
    public Rate(int newRate)
    {
        RateValue = newRate;
    }

    public int RateValue { get; set; }

    public static Rate Parse(string newParse) => new(int.Parse(newParse));
}
