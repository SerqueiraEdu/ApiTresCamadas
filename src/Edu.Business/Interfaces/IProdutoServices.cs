using Edu.Business.Models;

namespace Edu.Business.Interfaces
{
    public interface IProdutoServices : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
