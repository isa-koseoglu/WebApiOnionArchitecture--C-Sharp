using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.ConCreate
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<Hotel> HotelAdded(Hotel hotel)
        {
            using (var dbContext = new HotelDbContext())
            {
                dbContext.Hotels.Add(hotel);
                await dbContext.SaveChangesAsync();
                return  hotel;

            }
        }

        public async Task  HotelDeleted(int id)
        {
            using (var dbContext = new HotelDbContext())
            {
                var deleteHotel =await HotelGetById(id);
                if (deleteHotel != null)
                {
                    dbContext.Hotels.Remove(deleteHotel);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Hotel>> HotelGetAll()
        {
            using (var dbContext=new HotelDbContext())
            {
                return await dbContext.Hotels.ToListAsync();
            }
        }

        public async Task<Hotel> HotelGetById(int id)
        {
           using(var dbContext=new HotelDbContext())
            {
                
                return await dbContext.Hotels.FindAsync(id);
            }
        }

        public async Task<List<Hotel>> HotelGetName(string name)
        {
            
            using (var dbContext = new HotelDbContext())
            {
                var hotelName =await dbContext.Hotels.Where(p => p.Name.ToLower().StartsWith(name)).ToListAsync();
                return hotelName;
            }
        }

        public async Task<Hotel> HotelUpdated(Hotel hotel)
        {
            using (var dbContext = new HotelDbContext())
            {
                
                if (hotel != null)
                {
                    dbContext.Hotels.Update(hotel);
                    await dbContext.SaveChangesAsync();
                }
                return hotel;
            }
        }
    }
}
