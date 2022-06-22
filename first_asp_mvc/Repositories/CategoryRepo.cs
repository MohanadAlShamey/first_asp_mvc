using first_asp_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace first_asp_mvc.Repositories
{
    public class CategoryRepo : ICategory
    {
        private readonly DbApplication _db;


        public CategoryRepo(DbApplication db)
        {
            _db = db;
        }

        public async Task<bool> Add(CategoryApplication category)
        {
           _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            CategoryApplication? categoryApplication = await _db.Categories.FindAsync(id);
            CategoryApplication cat = categoryApplication;
            _db.Categories.Remove(cat);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Edit(CategoryApplication category)
        {
            CategoryApplication? categoryApplication = await _db.Categories.FindAsync(category.Id);
            CategoryApplication cat = categoryApplication;
            _db.Categories.Attach(entity: cat);
            cat = category;
           
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryApplication>> GetAll()
        {
            return await _db.Categories.ToListAsync();
        }

       public async Task<CategoryApplication> GetById(Guid id)
        {
            return await _db.Categories.FindAsync(id);
        }
    }
}
