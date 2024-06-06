using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using ProductsAPI.Utilities;
using RandomUserApp.Data;
using System;

namespace ProductsAPI.Services
{
    public class ProdutosService : IProdutoService
    {
        private readonly DataContext _context;

        public ProdutosService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateProduto(Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.Produto.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduto(Produto produto)
        {
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> GetAllProdutos()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            Produto produto = await _context.Produto.FindAsync(id);

            if (produto == null)
                throw new ServiceException("Registro não encontrado");

            return produto;
        }
    }
}
