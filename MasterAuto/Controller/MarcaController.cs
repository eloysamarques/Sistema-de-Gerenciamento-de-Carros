using MasterAuto.DTO;
using MasterAuto.Interfaces;
using MasterAuto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterAuto.Controller;

[Route("api/[controller]")]
[ApiController]
public class MarcaController : ControllerBase
{
    private readonly IMarcaRepository _marcaRepository;
    public MarcaController(IMarcaRepository tipoRepository)
    {
        _marcaRepository = tipoRepository;
    }

    /// <summary>
    /// Endpoint da API para chamada para o método listar as marcas
    /// </summary>
    /// <returns> Status code 200 e a lista de categoria</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_marcaRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API para chamada para o método listar as marcas
    /// </summary>
    /// <returns> Status code 200 e a lista de marcas</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_marcaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o método cadastrar uma nova marca
    /// </summary>
    /// <param name="carro">Marcas a ser cadastrado</param>
    /// <returns>Status code 201 e a marca cadastrada</returns>
    [HttpPost]
    public IActionResult Cadastrar(MarcaDTO marca)
    {
        try
        {
            var novaMarca = new Marca
            {
                NomeMarca = marca.NomeMarca!
            };
            _marcaRepository.Cadastrar(novaMarca);
            return StatusCode(201, marca);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o método atualizar uma marca
    /// </summary>
    /// <param name="id">Id da marca a ser atualizada</param>
    /// <param name="carro">Marca com os dados atualizados</param>
    /// <returns>Status code 204 e a marca atualizada</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, MarcaDTO marca)
    {
        try
        {
            var novaMarca = new Marca
            {
                NomeMarca = marca.NomeMarca!
            };
            _marcaRepository.Atualizar(id, novaMarca);
            return StatusCode(204, marca);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o método deletar uma marca
    /// </summary>
    /// <param name="id">Id da marca a ser excluída</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _marcaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
