namespace SmPlanner.Domain.Clienti;

public class PianificazioneGiorno
{
    public DayOfWeek Giorno { get; private set; }
    public bool Post { get; private set; }
    public bool Storie { get; private set; }
    public bool Reel { get; private set; }

    private PianificazioneGiorno()
    {
    }

    public PianificazioneGiorno(DayOfWeek giorno, bool post, bool storie, bool reel)
    {
        Giorno = giorno;
        Post = post;
        Storie = storie;
        Reel = reel;
    }
}
