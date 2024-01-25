﻿using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models;

public class DanaLogowania
{
    [Key]
    public Guid IDDanaLogowania { get; set; }
    [Required(ErrorMessage = "Pole wymagane.")]
    public string Haslo { get; set; } = string.Empty;
    [Required(ErrorMessage = "Pole wymagane.")]
    public string Email { get; set; } = string.Empty;

    public Bibliotekarz? Bibliotekarz { get; set; }
    public Czytelnik? Czytelnik { get; set; }
    public Admin? Admin { get; set; }

}
