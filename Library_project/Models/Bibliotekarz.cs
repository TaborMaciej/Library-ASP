﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models;

public class Bibliotekarz
{
    [Key]
    public Guid IDBibliotekarz { get; set; }
    [Required(ErrorMessage = "Pole wymagane.")]
    public int Pensja { get; set; } = 0;
    [ForeignKey("DanaOsobowa")]
    public Guid IDDanaOsobowe { get; set; }
    public virtual DanaOsobowa? DanaOsobowa{ get; set; }
    [ForeignKey("DanaLogowania")]
    public Guid IDDanaLogowania { get; set; }
    public virtual DanaLogowania? DanaLogowania { get; set; }

}
