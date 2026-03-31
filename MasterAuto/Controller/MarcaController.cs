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
