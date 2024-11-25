using Category2.Models;

namespace Category2.Services.IServices
{
    public class BaseServices : IBaseServices
    {
        private readonly DB db;
        private readonly ResponseDto responseDto;
        public BaseServices(DB dB)
        {
            db = dB;
            responseDto = new ResponseDto();
        }
        public async Task<ResponseDto> createcat(Categoryes cat)
        {
            try
            {
                db.Categoryes.Add(cat);
                db.SaveChanges();
                responseDto.issucses = true;
                responseDto.data = cat;
            }
            catch (Exception e)
            {

                responseDto.issucses = false;
                responseDto.message = e.Message;
            }
            return responseDto;
        }

        public async  Task<ResponseDto> readallcat()
        {
            try
            {
                List<Categoryes> ca =db.Categoryes.Select(a => a).ToList();
                responseDto.issucses = true;
                responseDto.data = ca;
            }
            catch (Exception e)
            {
                responseDto.issucses = false;
                responseDto.message = e.Message;
                throw;
            }
            return responseDto;
        }
    }
}
