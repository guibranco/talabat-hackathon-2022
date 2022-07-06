namespace TalabatHackathon.API.Models;

public class TranslateResponseModel
{
    public string Language { get; set; }
    public Dictionary<string, string> Texts { get; set; }
}