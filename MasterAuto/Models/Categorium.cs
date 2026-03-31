using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace MasterAuto.Models;

public partial class Categorium
{
    [Key]
    [Column("id_Categoria")]
    public Guid IdCategoria { get; set; }

    [Column("Nome_Categoria")]
    [StringLength(100)]
    public string? NomeCategoria { get; set; }

    [InverseProperty("IdCategoriaNavigation")]
    [JsonIgnore]
    public virtual ICollection<Carro> Carros { get; set; } = new List<Carro>();
}
