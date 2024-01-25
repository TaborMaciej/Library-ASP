﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library_project.Models;

    public class Osoba
    {
        [Key]
        public Guid IDOsoba { get; set; }
    [Required(ErrorMessage = "Pole wymagane.")]
    public string Imie { get; set; } = string.Empty;
    [Required(ErrorMessage = "Pole wymagane.")]
    public string Nazwisko { get; set; } = string.Empty;
        [Column(TypeName="Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? DataUrodzenia { get; set; }
        public bool CzyAutor { get; set; } = false;
    }


