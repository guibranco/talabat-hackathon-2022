namespace TalabatHackathon.API.Models;

public class TranslateRequestModel
{
    public string SourceLanguage { get; set; }
    public string DestinationLanguage { get; set; }

    public string Text { get; set; }
}