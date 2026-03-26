using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MasterAuto.Models;

[Keyless]
[Table("Carro")]
[Index("Placa", Name = "UQ__Carro__8310F99DEF5FCC53", IsUnique = true)]
public partial class Carro
{
    [StringLength(244)]
    public string Modelo { get; set; } = null!;

    [StringLength(8)]
    public string Placa { get; set; } = null!;

    [Column(TypeName = "decimal(12, 0)")]
    public decimal Valor { get; set; }

    [StringLength(100)]
    public string Imagem { get; set; } = null!;

    [StringLength(100)]
    public string Cor { get; set; } = null!;

    [Column("id_Categoria")]
    public Guid? IdCategoria { get; set; }

    [Column("id_Marca")]
    public Guid? IdMarca { get; set; }

    [ForeignKey("IdCategoria")]
    public virtual Categorium? IdCategoriaNavigation { get; set; }

    [ForeignKey("IdMarca")]
    public virtual Marca? IdMarcaNavigation { get; set; }
}
