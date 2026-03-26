using MasterAuto.Models;

namespace MasterAuto.Interfaces;

public interface ICarroRepository
{
    List<Carro> Listar();
    void Cadastrar (Carro carro);
    void Deletar (Guid id);
    void Atualizar (Guid id, Carro carro);
    Carro BuscarPorId(Guid Id);
}
