using Edu.Business.Models;

namespace Edu.Business.Interfaces
{
    public interface IFornecedorServices : IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Remover(Guid id);
    }
}
