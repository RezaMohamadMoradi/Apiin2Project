using product.Models;

namespace product.Repository.Interfaces
{
    public interface Iproductrepository
    {
        Task<ResponseDto> createproduct(productmodel product);
        Task<List<productmodel>> read();
    }
}
