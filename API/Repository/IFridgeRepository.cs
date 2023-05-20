using API.Models;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Repository
{
    public interface IFridgeRepository
    {
        public Task<IEnumerable<Fridge>> GetAll();
        public Task<Fridge> GetFridgeToId(Guid id);
        public Task<Fridge> Create(Fridge fridge);
        public Task<bool> UpdateFridge(Fridge fridge);
        public Task<bool> DeleteFridge(Fridge fridge);
    }
}
