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

    public Categorium BuscarPorId(Guid Id)
    {
        return _context.Categoria.Find(Id)!;
    }

    public void Cadastrar(Categorium categoria)
    {
        _context.Categoria.Add(categoria);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        Categorium categoriaBuscado = _context.Categoria.Find(id)!;
        if (categoriaBuscado != null)
        {
            _context.Categoria.Remove(categoriaBuscado);
            _context.SaveChanges();
        }
    }

    public List<Categorium> Listar()
    {
        return _context.Categoria.OrderBy(c => c.NomeCategoria).ToList();
    }
}
