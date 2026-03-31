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

    /// <summary>
    /// Atualiza um carro
    /// </summary>
    /// <param name="id">id a ser atualizado</param>
    /// <param name="carro">Qual carro sera atualizado</param>
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

    /// <summary>
    /// Método que busca um carro por seu Id. Que retorna o carro encontrado.
    /// </summary>
    /// <param name="Id">Id do carro a ser buscado</param>
    /// <returns>O carro equivalente ao Id</returns>
    public Carro BuscarPorId(Guid Id)
    {
        return _context.Carros.Find(Id)!;
    }

    /// <summary>
    /// Cadastra um carro
    /// </summary>
    /// <param name="carro">carro do tipo Carro a ser cadastrado</param>
    public void Cadastrar(Carro carro)
    {
        _context.Carros.Add(carro);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um carro
    /// </summary>
    /// <param name="id">id de carro a ser deletado</param>
    public void Deletar(Guid id)
    {
            Carro carroBuscado = _context.Carros.Find(id)!;
            if (carroBuscado != null)
            {
                _context.Carros.Remove(carroBuscado);
                _context.SaveChanges();
            }    
    }

    /// <summary>
    /// Busca a lista de carros cadastrados
    /// </summary>
    /// <returns>Retorna uma lista de carros já cadastrados</returns>
    public List<Carro> Listar()
    {
        return _context.Carros.OrderBy(c => c.Modelo).ToList();
    }
}
