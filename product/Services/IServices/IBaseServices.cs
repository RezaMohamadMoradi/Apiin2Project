using product.Models;

namespace product.Services.IServices
{
    public interface IBaseServices
    {

        Task<ResponseDto> result(requestdto requestdto);
    }
}
