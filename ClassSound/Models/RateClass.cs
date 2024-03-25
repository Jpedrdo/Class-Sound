namespace ClassSound.Models;

internal class RateClass
{
    public List<Rate> rateList = new();

    public float NoteAvarage
    {
        get
        {
            if (rateList.Count == 0) return 0;
            return GetAvarage();
        }
    }

    public void AddRate(Rate newRate) => rateList.Add(newRate);

    public float GetAvarage()
    {
        int allRatings = 0;
        foreach (int rating in rateList.Select(x => x.RateValue))
        {
            allRatings += rating;
        }
        return (float)allRatings / rateList.Count;
    }
}
