using MasterAuto.BdContextEvent;
using MasterAuto.Interfaces;
using MasterAuto.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MasterAuto.Repository;

public class CarroRepository : ICarroRepository
{
    private readonly MasterAutoContext _context;
    public CarroRepository(MasterAutoContext context)
    {
        _context = context;
    }   
    public void Atualizar(Guid id, Carro carro)
    {
        var carroAtualizado = _context.Carros.Find(id);
        if (carroAtualizado != null)
        {
           carroAtualizado.Modelo = carro.Modelo;
           carroAtualizado.Cor = carro.Cor;
           carroAtualizado.Valor = carro.Valor;
           carroAtualizado.Imagem = carro.Imagem;
           carroAtualizado.IdCategoria = carro.IdCategoria;
           carroAtualizado.IdMarca = carro.IdMarca;
            _context.SaveChanges();
        }
    }

    public Carro BuscarPorId(Guid Id)
    {
        return _context.Carros.Find(Id)!;
    }

    public void Cadastrar(Carro carro)
    {
        _context.Carros.Add(carro);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
            Carro carroBuscado = _context.Carros.Find(id)!;
            if (carroBuscado != null)
            {
                _context.Carros.Remove(carroBuscado);
                _context.SaveChanges();
            }    
    }

    public List<Carro> Listar()
    {
        return _context.Carros.OrderBy(c => c.Modelo).ToList();
    }
}
