using System.ComponentModel.DataAnnotations;

namespace TalabatHackathon.API.Models;

public class TranslateRequestModel
{
    [Required]
    public string SourceLanguage { get; set; }
    [Required]
    public string DestinationLanguage { get; set; }
    [Required]
    public Dictionary<string, string> Texts { get; set; }
}