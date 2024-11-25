using product.Models;

namespace product.Repository.Interfaces
{
    public interface Itodorepository
    {
        Task<List<todosdto>> readdto();
    }
}
