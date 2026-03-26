using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MasterAuto.Models;

[Table("Marca")]
public partial class Marca
{
    [Key]
    [Column("id_Marca")]
    public Guid IdMarca { get; set; }

    [Column("Nome_Marca")]
    [StringLength(100)]
    public string? NomeMarca { get; set; }
}
