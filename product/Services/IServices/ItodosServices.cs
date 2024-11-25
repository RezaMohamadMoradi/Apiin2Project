using product.Models;

namespace product.Services.IServices
{
    public interface ItodosServices
    {
        Task<List<todosdto>> readtodos();

    }
}
