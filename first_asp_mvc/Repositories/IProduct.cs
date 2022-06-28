using first_asp_mvc.Models;

namespace first_asp_mvc.Repositories
{
    public interface IProduct
    {
        public Task<bool> Add(ApplicationProduct product);
        public Task<bool> Edit(ApplicationProduct product);
        public Task<bool> Delete(Guid id);
        public Task<ApplicationProduct> GetById(Guid id);
        public Task<IEnumerable<ApplicationProduct>> GetAll();
    }
}
