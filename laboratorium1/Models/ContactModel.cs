using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace laboratorium1.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Поле Имя обязательно для заполнения.")]
    [MaxLength(20, ErrorMessage = "Имя не может быть длиннее 20 символов.")]
    [MinLength(2, ErrorMessage = "Имя должно быть не короче 2 символов.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Поле Фамилия обязательно для заполнения.")]
    [MaxLength(50, ErrorMessage = "Фамилия не может быть длиннее 50 символов.")]
    [MinLength(2, ErrorMessage = "Фамилия должна быть не короче 2 символов.")]
    public string LastName { get; set; }

    [EmailAddress(ErrorMessage = "Некорректный формат Email.")]
    public string Email { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Некорректный формат даты.")]
    public DateOnly DateBirt { get; set; }

    [Phone(ErrorMessage = "Некорректный формат номера телефона.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Выберите категорию.")]
    [Display(Name = "Категория")]
    public Category Category { get; set; }

}