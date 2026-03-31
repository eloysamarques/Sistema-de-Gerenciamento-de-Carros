using MasterAuto.BdContextEvent;
using MasterAuto.Interfaces;
using MasterAuto.Models;

namespace MasterAuto.Repository;

public class CategoriaRepository : ICategoriumRepository
{
    private readonly MasterAutoContext _context;
    public CategoriaRepository(MasterAutoContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza uma categoria
    /// </summary>
    /// <param name="id">id a ser atualizado</param>
    /// <param name="categoria">Qual categoria sera atualizado</param>
    public void Atualizar(Guid id, Categorium categoria)
    {
        var carroAtualizado = _context.Categoria.Find(id);
        if (carroAtualizado != null)
        {
            carroAtualizado.NomeCategoria = categoria.NomeCategoria;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Método que busca uma Categoria por seu Id. Que retorna a Categoria encontrado.
    /// </summary>
    /// <param name="Id">Id do categoria a ser buscado</param>
    /// <returns>O categoria equivalente ao Id</returns>
    public Categorium BuscarPorId(Guid Id)
    {
        return _context.Categoria.Find(Id)!;
    }

    /// <summary>
    /// Cadastra uma Categoria
    /// </summary>
    /// <param name="carro">categoria do tipo Categoria a ser cadastrado</param>
    public void Cadastrar(Categorium categoria)
    {
        _context.Categoria.Add(categoria);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta uma categoria
    /// </summary>
    /// <param name="id">id de categoria a ser deletado</param>
    public void Deletar(Guid id)
    {
        Categorium categoriaBuscado = _context.Categoria.Find(id)!;
        if (categoriaBuscado != null)
        {
            _context.Categoria.Remove(categoriaBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de categoria cadastrados
    /// </summary>
    /// <returns>Retorna uma lista de categoria já cadastrados</returns>
    public List<Categorium> Listar()
    {
        return _context.Categoria.OrderBy(c => c.NomeCategoria).ToList();
    }
}
