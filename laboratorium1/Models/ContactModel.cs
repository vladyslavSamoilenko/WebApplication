using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace laboratorium1.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Imie jest obowiązkowe")]
    [MaxLength(20, ErrorMessage = "Imie nie może przekrocic 20 znakow")]
    [MinLength(2, ErrorMessage = "Imie musi być dłuższe od 2 symboli")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Nazwisko jest obowiązkowe")]
    [MaxLength(50, ErrorMessage = "Nazwisko nie może przekrocic 50 znakow.")]
    [MinLength(2, ErrorMessage = "Nazwisko musi być dłuższe od 2 symboli")]
    public string LastName { get; set; }

    [EmailAddress(ErrorMessage = "Niepoprawny adres amilowy")]
    public string Email { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
    public DateOnly DateBirt { get; set; }

    [Phone(ErrorMessage = "Niepoprawny numer telefonu")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Wybierz kategorie")]
    [Display(Name = "Kategoria")]
    public Category Category { get; set; }

}