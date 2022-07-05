namespace TalabatHackathon.API.Models;

public class SpeechRequestModel
{
    public string SourceLanguage { get; set; }

    public string DestinationLanguage { get; set; }

    public string Text { get; set; }

}