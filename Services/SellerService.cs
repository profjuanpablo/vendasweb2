using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Entra a lógica de Negócio
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            //obj.Department=_context.Department.First();
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            if (_context == null)
            {
                throw new ArgumentNullException(nameof(_context), "Context is null");
            }
            // Carrega o vendedor com seu departamento
            var seller = await _context.Sellers
                                        .Include(obj => obj.Department)
                                        .FirstOrDefaultAsync(obj => obj.Id == id);

            // Verifica se o vendedor é nulo
            if (seller == null)
            {
                // Se não for encontrado nenhum vendedor com o ID especificado
                return null; // Ou você pode lançar uma exceção, se preferir
            }
            return seller;
            //return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try { 
            var obj = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(obj);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e) {
                throw new IntegrityException(e.Message);

            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {

                throw new NotFoundException("Não Achei o Dado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();

            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
