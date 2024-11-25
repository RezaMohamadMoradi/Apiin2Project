using product.Models;
using product.Repository.Interfaces;
using product.Repository.Interfaces;
using product.Services.IServices;

namespace product.Repository
{
    public class productrep : Iproductrepository
    {
        private readonly DBp _dBp;
        public productrep(DBp dBp)
        {
            _dBp = dBp;
        }
        public async Task<ResponseDto> createproduct(productmodel product )
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var result = _dBp.products.Add(product);
                await _dBp.SaveChangesAsync();
                response.issucses = true;
                response.message = "";
                response.data = result;
                return response;
            }
            catch (Exception e)
            {
                response.issucses = false;
                response.message = e.Message;
                response.data = null;
                return response;
            }
        }

        public async Task<List<productmodel>> read()
        {
            var list =_dBp.products.ToList();
            return list;
        }
    }
}
