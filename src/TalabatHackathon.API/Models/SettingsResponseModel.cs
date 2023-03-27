namespace TalabatHackathon.API.Models;

public class SettingsResponseModel
{
    public string[] TranslateIsoCodes { get; set; }

    public Dictionary<string, string> TranslateIsoPairs { get; set; }
}
