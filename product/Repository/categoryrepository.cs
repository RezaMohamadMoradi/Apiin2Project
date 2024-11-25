using product.Models;
using product.Repository.Interfaces;
using product.Services.IServices;

namespace product.Repository
{
    public class categoryrepository : icategory

    {
        private readonly IBaseServices _baseservice;
        public categoryrepository(IBaseServices baseServices)
        {
            _baseservice = baseServices;
        }
      

        async Task<ResponseDto> icategory.Getallcatshow()
        {
            var result = await _baseservice.result(new requestdto(){
                data=null,
                url= "https://localhost:7001/controller/readall",
                httpmetod=2

            });
                return result;
        }

         async Task<ResponseDto> icategory.createcat(CategoryesDto categoryesDto)
        {
            var result = await _baseservice.result(new requestdto()
            {
                data = categoryesDto,
                url = "https://localhost:7001/controller/create",
                httpmetod = 1

            });
            return result;
        }
    }
}
