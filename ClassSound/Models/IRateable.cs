namespace ClassSound.Models;

internal interface IRateable
{
    public float NoteAvarage { get; }
    void AddRate(Rate newRate);
}
