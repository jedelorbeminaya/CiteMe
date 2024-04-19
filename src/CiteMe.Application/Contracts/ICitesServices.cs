using CiteMe.Models;

namespace CiteMe.Application.Contracts
{
    public interface ICitesServices
    {
        bool Create(CitesModel cites);
        Task<CitesModel> Get(int id);
        Task<List<CitesModel>> GetAll();
        Task<bool> Remove(CitesModel cites);
    }
}