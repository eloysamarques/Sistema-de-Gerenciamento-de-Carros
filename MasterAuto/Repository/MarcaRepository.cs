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


    public void Atualizar(Guid id, Marca marca)
    {
        var marcaAtualizado = _context.Marcas.Find(id);
        if (marcaAtualizado != null)
        {
            marcaAtualizado.NomeMarca = marca.NomeMarca;
            _context.SaveChanges();
        }
    }

    public Marca BuscarPorId(Guid Id)
    {
        return _context.Marcas.Find(Id)!;
    }

    public void Cadastrar(Marca marca)
    {
        _context.Marcas.Add(marca);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        Marca marcaBuscado = _context.Marcas.Find(id)!;
        if (marcaBuscado != null)
        {
            _context.Marcas.Remove(marcaBuscado);
            _context.SaveChanges();
        }
    }

    public List<Marca> Listar()
    {
        return _context.Marcas.OrderBy(c => c.NomeMarca).ToList();
    }
}
