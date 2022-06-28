using first_asp_mvc.Models;

namespace first_asp_mvc.Repositories
{
    public interface ICategory
    {
        public Task<bool> Add(CategoryApplication category);
        public Task<bool> Edit(CategoryApplication category);
        public Task<bool> Delete(Guid id);
        public Task<CategoryApplication> GetById(Guid id);
        public Task<IEnumerable<CategoryApplication>> GetAll();
    }
}
