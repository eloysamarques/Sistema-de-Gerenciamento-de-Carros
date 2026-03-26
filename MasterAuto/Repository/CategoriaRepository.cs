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

    public void Atualizar(Guid id, Categorium categoria)
    {
        var carroAtualizado = _context.Categoria.Find(id);
        if (carroAtualizado != null)
        {
            carroAtualizado.NomeCategoria = categoria.NomeCategoria;
            _context.SaveChanges();
        }
    }

    public Categoria BuscarPorId(Guid Id)
    {
        return _context.Categoria.Find(Id)!;
    }

    public void Cadastrar(Categoria categoria)
    {
        throw new NotImplementedException();
    }

    public void Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Categoria> Listar()
    {
        throw new NotImplementedException();
    }
}
