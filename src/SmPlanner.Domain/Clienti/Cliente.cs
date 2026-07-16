namespace SmPlanner.Domain.Clienti;

public class Cliente
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Cognome { get; private set; } = string.Empty;
    public string? Societa { get; private set; }
    public string? Citta { get; private set; }
    public string? Telefono { get; private set; }
    public string? Email { get; private set; }
    public DateOnly DataInizioRapporto { get; private set; }
    public DateOnly? DataFineRapporto { get; private set; }
    public decimal ImportoMensile { get; private set; }
    public string? NoteEAccordi { get; private set; }
    public string ColoreHex { get; private set; } = string.Empty;
    public int SponsorizzateAlMese { get; private set; }
    public int NewsletterAlMese { get; private set; }

    private readonly List<PianificazioneGiorno> _pianificazione = [];
    public IReadOnlyCollection<PianificazioneGiorno> Pianificazione => _pianificazione.AsReadOnly();

    private Cliente()
    {
    }

    public Cliente(string nome, string cognome, DateOnly dataInizioRapporto, string coloreHex)
    {
        Id = Guid.NewGuid();
        AggiornaDatiAnagrafici(nome, cognome, null, null, null, null);
        DataInizioRapporto = dataInizioRapporto;
        ImpostaColore(coloreHex);
    }

    public void AggiornaDatiAnagrafici(string nome, string cognome, string? societa, string? citta, string? telefono, string? email)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("Il nome è obbligatorio.", nameof(nome));
        }

        if (string.IsNullOrWhiteSpace(cognome))
        {
            throw new ArgumentException("Il cognome è obbligatorio.", nameof(cognome));
        }

        Nome = nome;
        Cognome = cognome;
        Societa = societa;
        Citta = citta;
        Telefono = telefono;
        Email = email;
    }

    public void AggiornaRapporto(DateOnly dataInizioRapporto, DateOnly? dataFineRapporto, decimal importoMensile, string? noteEAccordi)
    {
        if (dataFineRapporto is not null && dataFineRapporto < dataInizioRapporto)
        {
            throw new ArgumentException("La data di fine rapporto non può precedere la data di inizio.", nameof(dataFineRapporto));
        }

        if (importoMensile < 0)
        {
            throw new ArgumentException("L'importo mensile non può essere negativo.", nameof(importoMensile));
        }

        DataInizioRapporto = dataInizioRapporto;
        DataFineRapporto = dataFineRapporto;
        ImportoMensile = importoMensile;
        NoteEAccordi = noteEAccordi;
    }

    public void AggiornaPianificazioneContenuti(IEnumerable<PianificazioneGiorno> pianificazione, int sponsorizzateAlMese, int newsletterAlMese)
    {
        if (sponsorizzateAlMese < 0)
        {
            throw new ArgumentException("Le sponsorizzate al mese non possono essere negative.", nameof(sponsorizzateAlMese));
        }

        if (newsletterAlMese < 0)
        {
            throw new ArgumentException("Le newsletter al mese non possono essere negative.", nameof(newsletterAlMese));
        }

        _pianificazione.Clear();
        _pianificazione.AddRange(pianificazione);
        SponsorizzateAlMese = sponsorizzateAlMese;
        NewsletterAlMese = newsletterAlMese;
    }

    public void ImpostaColore(string coloreHex)
    {
        if (string.IsNullOrWhiteSpace(coloreHex))
        {
            throw new ArgumentException("Il colore è obbligatorio.", nameof(coloreHex));
        }

        ColoreHex = coloreHex;
    }
}
