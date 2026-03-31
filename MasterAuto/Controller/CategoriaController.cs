using MasterAuto.DTO;
using MasterAuto.Interfaces;
using MasterAuto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterAuto.Controller;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriumRepository _categoriaRepository;
    public CategoriaController(ICategoriumRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_categoriaRepository.Listar());
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
            return Ok(_categoriaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPost]
    public IActionResult Cadastrar(CategoriaDTO categoria)
    {
        try
        {
            var novaCategoria = new Categorium
            {
                NomeCategoria = categoria.NomeCategoria!
            };
            _categoriaRepository.Cadastrar(novaCategoria);
            return StatusCode(201, categoria);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, CategoriaDTO categoria)
    {
        try
        {
            var novoTipoEvento = new Categorium
            {
                NomeCategoria = categoria.NomeCategoria!
            };
            _categoriaRepository.Atualizar(id, novoTipoEvento);
            return StatusCode(204, categoria);
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
            _categoriaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
