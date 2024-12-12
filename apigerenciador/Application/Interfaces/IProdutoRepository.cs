using apigerenciador.domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apigerenciador.Application.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> GetAllAsync();
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);

    }
}
