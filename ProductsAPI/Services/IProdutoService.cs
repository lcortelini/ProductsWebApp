using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAllProdutos();
        Task<Produto> GetProdutoById(int id);
        Task CreateProduto(Produto produto);
        Task UpdateProduto(Produto produto);
        Task DeleteProduto(Produto produto);
    }
}
