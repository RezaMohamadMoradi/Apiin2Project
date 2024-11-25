using Category2.Models;

namespace Category2.Services.IServices
{
    public interface IBaseServices
    {
        Task<ResponseDto> readallcat();
        Task<ResponseDto> createcat(Categoryes cat);

    }
}
