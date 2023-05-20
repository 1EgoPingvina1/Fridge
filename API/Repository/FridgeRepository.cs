using API.Models;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Repository
{
#nullable disable
    public class FridgeRepository : IFridgeRepository
    {
        public readonly FridgeDataBaseContext _context;
        public FridgeRepository(FridgeDataBaseContext context) => _context = context;

        public async Task<Fridge> Create(Fridge fridge)
        {
            _context.Fridges.Add(new Fridge()
            {
                Id = fridge.Id,
                Name = fridge.Name,
                OwnerName= fridge.OwnerName,
                ModelId= fridge.ModelId
            });
            await _context.SaveChangesAsync();
            return fridge;
        }

        public async Task<IEnumerable<Fridge>> GetAll() => await _context.Fridges.ToListAsync();
        public async Task<Fridge> GetFridgeToId(Guid id) => await _context.Fridges.FindAsync(id);

        public async Task<bool> DeleteFridge(Fridge fridge)
        {
            var FindValueForDelete = await _context.Fridges.FirstOrDefaultAsync();
            if (FindValueForDelete != null)
            {
                _context.Entry(FindValueForDelete).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateFridge(Fridge fridge)
        {
            var Updater = await _context.Fridges.Where(x => x.Id == fridge.Id).FirstOrDefaultAsync<Fridge>();
            if(Updater != null) 
            {
                Updater.Name = fridge.Name;
                Updater.OwnerName = fridge.OwnerName;
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;  
        }
    }
}
