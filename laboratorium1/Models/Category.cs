using System.ComponentModel.DataAnnotations;

namespace laboratorium1.Models;

public enum Category
{
    [Display(Name = "Rodzina")]
    Family = 1,

    [Display(Name = "Znajomi")]
    Friend = 2,

    [Display(Name = "Kontakt zawodowy")]
    Business = 3
}