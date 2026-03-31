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

    /// <summary>
    /// Endpoint da API para chamada para o método listar as Categorias
    /// </summary>
    /// <returns> Status code 200 e a lista de categoria</returns>
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

    /// <summary>
    /// Endpoint da API que faz chamada para o método buscar por id do categoria especifico
    /// </summary>
    /// <param name="Id">id da categoria buscada</param>
    /// <returns> Status code 200 e o tipo de categoria buscada</returns>
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

    /// <summary>
    /// Endpoint da API que faz chamada para o método cadastrar uma nova categoria
    /// </summary>
    /// <param name="carro">Categoria a ser cadastrado</param>
    /// <returns>Status code 201 e a categoria cadastrada</returns>
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

    /// <summary>
    /// Endpoint da API que faz chamada para o método atualizar uma categoria
    /// </summary>
    /// <param name="id">Id da categoria a ser atualizada</param>
    /// <param name="carro">Categoria com os dados atualizados</param>
    /// <returns>Status code 204 e a categoria atualizada</returns>
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

    /// <summary>
    /// Endpoint da API que faz chamada para o método deletar uma categoria
    /// </summary>
    /// <param name="id">Id da categoria a ser excluída</param>
    /// <returns>Status code 204</returns>
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
