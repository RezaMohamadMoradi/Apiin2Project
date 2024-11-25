using product.Models;

namespace product.Repository.Interfaces
{
    public interface icategory
    {
         Task<ResponseDto> Getallcatshow();
        Task<ResponseDto> createcat(CategoryesDto categoryesDto);

    }
}
