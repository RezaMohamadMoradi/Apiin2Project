using product.Models;
using product.Repository.Interfaces;
using product.Services.IServices;

namespace product.Repository
{
    public class todoreposetory : Itodorepository
    {
        private readonly ItodosServices todosServices;
        public todoreposetory(ItodosServices itodos)
        {
                todosServices = itodos;
        }
        public async Task<List<todosdto>> readdto()
        {
           var res = await todosServices.readtodos();
            return res;
        }
    }
}
