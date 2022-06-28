using first_asp_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace first_asp_mvc.Repositories
{
    public class ProductRepo : IProduct
    {
        private readonly DbApplication _db;
            public ProductRepo(DbApplication db)
        {
            _db = db;
        }
        public async Task<bool> Add(ApplicationProduct product)
        {
           _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            ApplicationProduct product = await _db.Products.FindAsync(id);
            _db.Products.Remove(product);
           await _db.SaveChangesAsync();return true;
        }

        public async Task<bool> Edit(ApplicationProduct product)
        {
            ApplicationProduct pr = 
                await _db.Products.Include(x=>x.CategoryApplication).FirstOrDefaultAsync(x=>x.Id==product.Id);
            pr = product;
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<ApplicationProduct>> GetAll()
        {
            return 
                  await _db.Products.Include(x => x.CategoryApplication).OrderBy(x=>x.Name).ToListAsync();
        }

        public async Task<ApplicationProduct> GetById(Guid id)
        {
            return
                   await _db.Products.Include(x => x.CategoryApplication).OrderBy(x => x.Name).FirstOrDefaultAsync(x => x.Id ==id);
        }
    }
}
