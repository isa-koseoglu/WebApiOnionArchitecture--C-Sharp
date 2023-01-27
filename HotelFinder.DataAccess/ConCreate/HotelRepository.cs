using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.ConCreate
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel HotelAdded(Hotel hotel)
        {
            using (var dbContext = new HotelDbContext())
            {
                dbContext.Hotels.Add(hotel);
                dbContext.SaveChanges();
                return hotel;

            }
        }

        public void HotelDeleted(int id)
        {
            using (var dbContext = new HotelDbContext())
            {
                var deleteHotel = HotelGetById(id);
                if (deleteHotel != null)
                {
                    dbContext.Hotels.Remove(deleteHotel);
                    dbContext.SaveChanges();
                }
                    

            }
        }

        public List<Hotel> HotelGetAll()
        {
            using (var dbContext=new HotelDbContext())
            {
                return dbContext.Hotels.ToList();
            }
        }

        public Hotel HotelGetById(int id)
        {
           using(var dbContext=new HotelDbContext())
            {
                var byIdHotel = dbContext.Hotels.ToList().Find(p => p.Id == id);
                return byIdHotel;
            }
        }

        public List<Hotel> HotelGetName(string name)
        {
            
            using (var dbContext = new HotelDbContext())
            {
                var hotelName = dbContext.Hotels.Where(p => p.Name.ToLower().StartsWith(name)).ToList();
                return hotelName;
            }
        }

        public Hotel HotelUpdated(Hotel hotel)
        {
            using (var dbContext = new HotelDbContext())
            {
                
                if (hotel != null)
                {
                    dbContext.Hotels.Update(hotel);
                    dbContext.SaveChanges();
                }
                return hotel;
            }
        }
    }
}
