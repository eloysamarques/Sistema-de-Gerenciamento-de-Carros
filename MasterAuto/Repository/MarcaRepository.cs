using MasterAuto.BdContextEvent;
using MasterAuto.Interfaces;
using MasterAuto.Models;

namespace MasterAuto.Repository;

public class MarcaRepository : IMarcaRepository
{

    private readonly MasterAutoContext _context;
    public MarcaRepository(MasterAutoContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza uma marca
    /// </summary>
    /// <param name="id">id a ser atualizado</param>
    /// <param name="categoria">Qual marca sera atualizado</param>
    public void Atualizar(Guid id, Marca marca)
    {
        var marcaAtualizado = _context.Marcas.Find(id);
        if (marcaAtualizado != null)
        {
            marcaAtualizado.NomeMarca = marca.NomeMarca;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca o id de uma Marca em especifico
    /// </summary>
    /// <param name="Id">Id da marca a ser buscado</param>
    /// <returns>A marca equivalente ao Id</returns>
    public Marca BuscarPorId(Guid Id)
    {
        return _context.Marcas.Find(Id)!;
    }

    /// <summary>
    /// Cadastra uma marca
    /// </summary>
    /// <param name="carro">categoria do tipo Marca a ser cadastrado</param>
    public void Cadastrar(Marca marca)
    {
        _context.Marcas.Add(marca);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta uma marca
    /// </summary>
    /// <param name="id">id de marca a ser deletado</param>
    public void Deletar(Guid id)
    {
        Marca marcaBuscado = _context.Marcas.Find(id)!;
        if (marcaBuscado != null)
        {
            _context.Marcas.Remove(marcaBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de marca cadastrados
    /// </summary>
    /// <returns>Retorna uma lista de marcas já cadastrados</returns>
    public List<Marca> Listar()
    {
        return _context.Marcas.OrderBy(c => c.NomeMarca).ToList();
    }
}
