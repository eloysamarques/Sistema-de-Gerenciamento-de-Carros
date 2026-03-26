using MasterAuto.Models;

namespace MasterAuto.Interfaces
{
    public interface ICategoriumRepository
    {
        List<Categorium> Listar();
        void Cadastrar (Categorium categoria);
        void Deletar (Guid id);
        void Atualizar (Guid id, Categorium categoria);
        Categorium BuscarPorId(Guid Id);
    }
}
