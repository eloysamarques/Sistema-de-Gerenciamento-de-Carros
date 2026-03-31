using System.ComponentModel.DataAnnotations;

namespace MasterAuto.DTO;

public class CarroDTO
{
    [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
   
    public string Modelo { get; set; } = null!;
    public string Placa { get; set; } = null!;
    public Decimal Valor { get; set; }
    public IFormFile Imagem { get; set; } = null!;
    public string Cor { get; set; } = null!;
    public Guid IdCategoria { get; set; }
    public Guid IdMarca { get; set; }
}
