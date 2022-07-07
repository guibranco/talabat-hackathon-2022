using System.ComponentModel.DataAnnotations;

namespace TalabatHackathon.API.Models;

public class TranslateRequestModel
{
    [Required]
    public string SourceLanguage { get; set; }
    [Required]
    public string DestinationLanguage { get; set; }
    [Required]
    public string[] Texts { get; set; }
}