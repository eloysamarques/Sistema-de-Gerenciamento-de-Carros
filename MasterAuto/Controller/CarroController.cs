using MasterAuto.DTO;
using MasterAuto.Interfaces;
using MasterAuto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterAuto.Controller;

[Route("api/[controller]")]
[ApiController]
public class CarroController : ControllerBase
{
    private readonly ICarroRepository _carroRepository;

    public CarroController(ICarroRepository carroRepository)
    {
        _carroRepository = carroRepository;
    }

    /// <summary>
    /// Endpoint da API para chamada para o método listar os carros
    /// </summary>
    /// <returns> Status code 200 e a lista de carros</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_carroRepository.Listar());
        }
        catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o método buscar por id do carro especifico
    /// </summary>
    /// <param name="Id">id do carro buscado</param>
    /// <returns> Status code 200 e o tipo de carro buscado</returns>
    [HttpGet("{Id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_carroRepository.BuscarPorId(Id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o método cadastrar um novo carro
    /// </summary>
    /// <param name="carro">Carro a ser cadastrado</param>
    /// <returns>Status code 201 e o carro cadastrado</returns>
    [HttpPost]
    public async Task<IActionResult> CadastrarAsync(CarroDTO carro) 
    {
        if (String.IsNullOrWhiteSpace(carro.Modelo))
            return BadRequest("É obrigatório que o Carro tenha um modelo");

        Carro novoCarro = new Carro();

        if (carro.Imagem != null && carro.Imagem.Length != 0)
        {
            var extensao = Path.GetExtension(carro.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            //Garante que a pasta exista
            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await carro.Imagem.CopyToAsync(stream);
            }

            novoCarro.Modelo = carro.Modelo;
            novoCarro.Placa = carro.Placa;
            novoCarro.Valor = carro.Valor;
            novoCarro.Imagem = nomeArquivo;
            novoCarro.Cor = carro.Cor!;
            novoCarro.IdCategoria = carro.IdCategoria;
            novoCarro.IdMarca = carro.IdMarca;
        }

        try
        {
            _carroRepository.Cadastrar(novoCarro);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o método atualizar um carro
    /// </summary>
    /// <param name="id">Id do carro a ser atualizado</param>
    /// <param name="carro">Carro com os dados atualizados</param>
    /// <returns>Status code 204 e o carro atualizado</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, CarroDTO carro)
    {
        var carroBuscado = _carroRepository.BuscarPorId(id); ;
        if (carroBuscado == null)
            return NotFound("Filme não encontrado!");

        if (!String.IsNullOrWhiteSpace(carro.Modelo))
            carroBuscado.Modelo = carro.Modelo;

        if ((carro.Valor) > 0)
            carroBuscado.Valor = carro.Valor;

        if (!String.IsNullOrWhiteSpace(carro.Placa))
            carroBuscado.Placa = carro.Placa;

        if (!String.IsNullOrWhiteSpace(carro.Cor))
            carroBuscado.Cor = carro.Cor;

        if (carroBuscado.IdCategoria != carro.IdCategoria)
            carroBuscado.IdCategoria = carro.IdCategoria;

        if (carroBuscado.IdMarca != carro.IdMarca)
            carroBuscado.IdMarca = carro.IdMarca;

        if (carro.Imagem != null && carro.Imagem.Length != 0)
        {
            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            //Deleta arquivo antigo
            if (!string.IsNullOrEmpty(carroBuscado.Imagem))
            {
                var caminhoAntigo = Path.Combine(caminhoPasta, carroBuscado.Imagem);

                if (System.IO.File.Exists(caminhoAntigo))
                    System.IO.File.Delete(caminhoAntigo);
            }

            //Salva a nova imagem
            var extensao = Path.GetExtension(carro.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await carro.Imagem.CopyToAsync(stream);
            }

            carroBuscado.Imagem = nomeArquivo;
        }
        try
        {
            _carroRepository.Atualizar(id, carroBuscado);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o método deletar um carro
    /// </summary>
    /// <param name="id">Id do carro a ser excluído</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var carroBuscado = _carroRepository.BuscarPorId(id);
        if (carroBuscado == null)
            return NotFound("Filme não encontrado!");

        var pastaRelativa = "wwwroot/imagens";
        var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

        //Deleta o arquivo
        if (!String.IsNullOrEmpty(carroBuscado.Imagem))
        {
            var caminho = Path.Combine(caminhoPasta, carroBuscado.Imagem);

            if (System.IO.File.Exists(caminho))
                System.IO.File.Delete(caminho);
        }

        try
        {
            _carroRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
}
