﻿using System.ComponentModel.DataAnnotations;

namespace Library_project.Models;

public class Gatunek
{
    [Key]
    public Guid? IDGatunek { get; set; }
    [Required(ErrorMessage = "Pole wymagane.")]
    public string Nazwa { get; set; } = string.Empty;

    public virtual List<Ksiazka>? Ksiazki { get; set; }
}
