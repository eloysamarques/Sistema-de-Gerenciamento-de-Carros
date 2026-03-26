using MasterAuto.Models;

namespace MasterAuto.Interfaces;

public interface IMarcaRepository
{
    List<Marca> Listar();
    void Cadastrar (Marca marca);
    void Deletar (Guid id);
    void Atualizar (Guid id, Marca marca);
    Marca BuscarPorId(Guid Id);
}
